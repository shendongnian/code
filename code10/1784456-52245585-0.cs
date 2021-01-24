    using System.IO;
    using System.Collections.Generic;
    
    namespace ConsoleApp3
    {
        public class Program
        {
            static void Main(string[] args)
            {
                int lineNumber = 4;
                string filePath = @"C:\Users\Admin\Desktop\test - Copy.txt";
                List<string> lines = new List<string>();
                using (TextReader tr = new StreamReader(filePath))
                {
                    int i = 0;
                    while(i!=lineNumber)
                    {
                        lines.Add(tr.ReadLine());
                        i++;
                    }
                }
                File.Delete(filePath);
                File.WriteAllLines(filePath,lines);
            }
        }
    }
