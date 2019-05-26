using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MakingWaves
{
    class Program
    {
        public static Dictionary<int, int> goodDate = new Dictionary<int, int>();
        
        static void Main(string[] args)
        {

            string regex1 = @"(\d{2})\.(\d{2})\.(\d{4})";

            if (args.Length == 2 && Regex.IsMatch(args[0], regex1) && Regex.IsMatch(args[1], regex1))
            {
                convertingDates(args, regex1);
            }
            else
            {
                Console.WriteLine("Złe argumenty");
            } 
        }


        static void incrementDictionary()
        {
            goodDate.Add(1, 31);
            goodDate.Add(2, 28);
            goodDate.Add(3, 31);
            goodDate.Add(4, 30);
            goodDate.Add(5, 31);
            goodDate.Add(6, 30);
            goodDate.Add(7, 31);
            goodDate.Add(8, 31);
            goodDate.Add(9, 30);
            goodDate.Add(10, 31);
            goodDate.Add(11, 30);
            goodDate.Add(12, 31);
        }

        //PRZETWARZA PODANE ARGUMENTY 
        static void convertingDates(string[] args, string regex1)
        {

            Match firstDate;
            Match secondDate;

            firstDate = Regex.Match(args[0], regex1);
            secondDate = Regex.Match(args[1], regex1);

            incrementDictionary();

            int[] first = makeArray(firstDate);
            int[] second = makeArray(secondDate);



            if (correctType(first[0], first[1]) && correctType(second[0], second[1])) writeDate(first, second);
            else Console.WriteLine("Podałeś date ale taka nie istnieje!"); 
        }
        //WYPISUJE DATE W ZALEŻNOŚCI OD ICH TYPU
        static void writeDate(int[] first, int[] second)
        {
            possitionDates(ref first, ref second);
            var secondallDate = rightDate(second[0]) + "." + rightDate(second[1]) + "." + rightDate(second[2]);
            var firstallDate = rightDate(first[0]) + "." + rightDate(first[1]) + "." + rightDate(first[2]);
            if (first[1] == second[1] && first[2] == second[2])
            {
                Console.WriteLine("{0} - {1}", rightDate(first[0]), secondallDate);
            }

            else if (first[2] == second[2])
            {
                Console.WriteLine("{0}.{1} - {2}", rightDate(first[0]), rightDate(first[1]), secondallDate);
            }
            else
            {
                Console.WriteLine("{0} - {1}", firstallDate, secondallDate);
            }
        }
        //TWORZY TABLICE ZAWIERAJĄCĄ DZIEŃ MIESIĄC ROK
        static int[] makeArray(Match matchDate)
        {
                int[] arr = { Convert.ToInt32((matchDate.Groups[1].ToString())), Convert.ToInt32((matchDate.Groups[2].ToString())), Convert.ToInt32((matchDate.Groups[3].ToString())) };
                return arr;            
        }
        //DOPISUJE "0" DO LICZNY MNIEJSZEJ OD 10
        static string rightDate(int a)
        {
            if (a <= 9) return "0" + a;
            else return a.ToString();
        }
        //SPRAWDZA CZY PODANA DATA ISTNIEJE 
        static bool correctType(int day, int month)
        {
            try
            {
                var maxMonth = goodDate.Where(x => x.Key == month).FirstOrDefault().Value;
                if (day > maxMonth) return false;
                else return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        // SPRAWDZA I ZAMIENIA ARGUMENTYW PRZYPADKU ZŁEJ KOLEJNOŚCI
        static void possitionDates(ref int[] a, ref int[] b)
        {
            if (a[2] > b[2])
            {
                swap(ref a, ref b);
            }
            else if (a[1] > b[1])
            {
                swap(ref a, ref b);
            }
            else if(a[0] > b[0])
            {
                swap(ref a, ref b);
            }
        }

        static void swap(ref int[] a, ref int[] b)
        {
            int[] val;
            val = a;
            a = b;
            b = val;
        }



    }
}
