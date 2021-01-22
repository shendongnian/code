    using System;
    using System.IO;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                TextReader reader = new StreamReader(File.OpenRead("c:\\myfile.txt"));
    
                string line = reader.ReadLine();
    
                while (!String.IsNullOrEmpty(line))
                {
                    // do stuff. 
                }
    
                reader.Close();
            }
        }
    }
