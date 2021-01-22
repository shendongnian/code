    using System;
    using System.Diagnostics;
    using System.Security.Cryptography;
    using System.Text;
    
    namespace ConsoleApplication11
    {
        class Program
        {
            static void Main(string[] args)
            {
                Stopwatch timer=new Stopwatch();
                int iterations = 100000;
                timer.Start();
                for (int i = 0; i < iterations; i++)
                {
                    string s = "test" + i;
                    string t=s.ToMd5Hash0();
                }
                timer.Stop();
                Console.WriteLine(timer.ElapsedTicks);
    
                timer.Reset();
                timer.Start();
                for (int i = 0; i < iterations; i++)
                {
                    string s = "test" + i;
                    string t = s.ToMd5Hash1();
                }
                timer.Stop();
                Console.WriteLine(timer.ElapsedTicks);
    
                Console.ReadKey();
            }
        }
        public static class Md5Factory
        {
            private static MD5CryptoServiceProvider md5CryptoServiceProvider;
            public static string ToMd5Hash0(this string value)
            {
                if (md5CryptoServiceProvider == null)
                {
                    md5CryptoServiceProvider = new MD5CryptoServiceProvider();
                }
                byte[] newData = Encoding.Default.GetBytes(value);
                byte[] encrypted = md5CryptoServiceProvider.ComputeHash(newData);
                return BitConverter.ToString(encrypted).Replace("-", "").ToLower();
            }
            public static string ToMd5Hash1(this string value)
            {
                using (var provider = new MD5CryptoServiceProvider())
                {
                    byte[] newData = Encoding.Default.GetBytes(value);
                    byte[] encrypted = provider.ComputeHash(newData);
                    return BitConverter.ToString(encrypted).Replace("-", "").ToLower();
                }
            }
        }
    }
