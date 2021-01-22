    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
    namespace testing
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                string file = @"C:\Temp\New Folder\New Text Document.txt";
                using(FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {                    
                    using(StreamReader sr = new StreamReader(fs))
                    {
                        while(!sr.EndOfStream)
                        {
                           Console.WriteLine(sr.ReadLine());
                        }
                    }
                }
            }
        }
    }
