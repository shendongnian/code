    sing System;
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
                StreamReader reader = new StreamReader(FILENAME);
                string line = "";
                List<string> data = new List<string>();
                while((line = reader.ReadLine()) != null)
                {
                    data.Add(line);
                }
                //read line 5 character 6
                char c5_6 = data[4][5];
            }
        }
    }
