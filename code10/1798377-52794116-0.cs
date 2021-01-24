    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                List<List<string>> data = new List<List<string>>();
                StreamReader reader = new StreamReader(FILENAME);
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    List<string> lineArray = line.Split(new char[] { ':' }).ToList();
                    data.Add(lineArray);
                }
                reader.Close();
            }
        }
    }
