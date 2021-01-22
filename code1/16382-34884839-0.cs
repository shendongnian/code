    using System;
    using System.Diagnostics;
    using System.Text;
    using System.Text.RegularExpressions;
    public class Program
    {
        private static Regex digitsOnly = new Regex(@"[^\d]");
        public static void Main()
        {
            Console.WriteLine("Init...");
            string phone = "001-12-34-56-78-90";
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                DigitsOnly(phone);
            }
            sw.Stop();
            Console.WriteLine("Time: " + sw.ElapsedMilliseconds);
            var sw2 = new Stopwatch();
            sw2.Start();
            for (int i = 0; i < 1000000; i++)
            {
                DigitsOnlyRegex(phone);
            }
            sw2.Stop();
            Console.WriteLine("Time: " + sw2.ElapsedMilliseconds);
        
            Console.ReadLine();
        }
        public static string DigitsOnly(string phone, string replace = null)
        {
            if (replace == null) replace = "";
            if (phone == null) return null;
            var result = new StringBuilder(phone.Length);
            foreach (char c in phone)
                if (c >= '0' && c <= '9')
                    result.Append(c);
                else
                {
                    result.Append(replace);
                }
            return result.ToString();
        }
        public static string DigitsOnlyRegex(string phone)
        {
            return digitsOnly.Replace(phone, "");
        }
    }
