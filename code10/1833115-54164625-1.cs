    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Data;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                FixedColumnWidth fixColumnWidth = new FixedColumnWidth();
                DataTable dt =  fixColumnWidth.ReadFile(FILENAME);
            }
        }
        public class FixedColumnWidth
        {
            public DataTable ReadFile(string filename)
            {
                string line = "";
                string pattern = @"^\d+$";
                StreamReader reader = new StreamReader(filename);
                DataTable dt = new DataTable();
                dt.Columns.Add("Index", typeof(int));
                dt.Columns.Add("Date", typeof(DateTime));
                dt.Columns.Add("Amount", typeof(string));
                dt.Columns.Add("Value", typeof(int));
                
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Trim().Length > 0)
                    {
                        List<string> row = GetData(line);
                        Match match = Regex.Match(row[0].Trim(), pattern);
                        if (match.Success)
                        {
                            dt.Rows.Add(new object[] {
                                int.Parse(row[0]),
                                DateTime.Parse(row[1] + " " + row[2]),
                                row[3],
                                int.Parse(row[4])
                            }); 
                        }
                    }
                }
                return dt;
            }
            private List<string> GetData(string line)
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
                        
                        array.Add(line.Substring(START_COLUMNS[startCol], START_COLUMNS[startCol + 1] - START_COLUMNS[startCol]).Trim(new char[] { ',', ' '}));
                    }
                }
                return array;
            }
        }
    }
