    using System;
    using System.IO;
    
    namespace ConsoleApplication72
    {
        class Program
        {
            static void Main(string[] args)
            {
                string filename = "c:\\bláh\\bleh";
    
                FileInfo fi = new FileInfo(filename);
    
                Console.WriteLine(fi.Exists);
    
                Console.ReadLine();
            }
        }
    }
