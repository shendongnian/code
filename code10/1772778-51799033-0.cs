    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"Files/plain_32m.tsv";
            static void Main(string[] args)
            {
                int rowCount = 0;
                StreamReader reader = new StreamReader(FILENAME);
                string line = "";
                DataTable dt = new DataTable();
                while ((line = reader.ReadLine()) != null)
                {
                    string[] tsv = line.Split(new char[] { '\t' }).ToArray();
                    //remove any end spaces from data
                    tsv = tsv.Select(x => x.Trim()).ToArray();
                    if (++rowCount == 1)
                    {
                        foreach (string colName in tsv)
                        {
                            dt.Columns.Add(colName, typeof(string));
                        }
                    }
                    else
                    {
                        dt.Rows.Add(tsv);
                    }
                }
            }
        }
    }
 
