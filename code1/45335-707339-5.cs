    using System;
    using System.IO;
    
    class Program
    {
        public static void Main(string[] args)
        {
            for (int i=0; i < 1000; i++)
            {
                using(StreamReader sr = new StreamReader
                      (File.Open("somefile.txt", FileMode.Open)))
                {
                    Console.WriteLine(sr.ReadLine());
                }
                File.Move("somefile.txt", "somefile.bak");
                File.Move("somefile.bak", "somefile.txt");
            }
        }
    }
