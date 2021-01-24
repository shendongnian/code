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
                string line = "";
                StreamReader reader = new StreamReader(FILENAME);
                List<List<string>> data = new List<List<string>>();
                while((line = reader.ReadLine()) != null)
                {
                    List<string> row = GetData(line);
                    data.Add(row);
                }
            }
            static List<string> GetData(string line)
            {
                int[] START_COLUMNS = { 0, 17, 41, 57, 69 };
                List<string> array = new List<string>();
                for (int startCol = 0; startCol < START_COLUMNS.Count(); startCol++)
                {
                    if (startCol == START_COLUMNS.Count() - 1)
                    {
                        array.Add(line.Substring(START_COLUMNS[startCol]).Trim());
                    }
                    else
                    {
                        array.Add(line.Substring(START_COLUMNS[startCol], START_COLUMNS[startCol + 1] - START_COLUMNS[startCol]).Trim().Trim(new char[] {'|'}));
                    }
                }
                return array;
            }
        }
    }
