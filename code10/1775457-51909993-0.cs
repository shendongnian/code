    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        public class Program
        {
            private static void Main()
            {
                List<List<string>> data = new List<List<string>>() {
                    new List<string>() { "Name", "Age", "Weight"},
                    new List<string>() { "John", "33", "180"},
                    new List<string>() { "Mary", "32", "125"},
                    new List<string>() { "Harry", "40", "200"}
                };
                DataTable dt = new DataTable();
                for (int i = 0; i < data.Count; i++)
                {
                    if (i == 0)
                    {
                        foreach (string col in data[i])
                        {
                            dt.Columns.Add(col);
                        }
                    }
                    else
                    {
                        dt.Rows.Add(data[i].ToArray());
                    }
                }
            }
        }
     
    }
