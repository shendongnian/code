    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable  dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("CID", typeof(string));
                dt.Columns.Add("CountryName", typeof(string));
                dt.Rows.Add(new object[] {1, "0000", "UK"});
                dt.Rows.Add(new object[] {2, "1111", "JAPAN"});
                dt.Rows.Add(new object[] {3, "2222", "CHINA"});
                dt.Rows.Add(new object[] {4, "3333", "SRI LANKA"});
                dt.Rows.Add(new object[] {5, "4444", "AUSI"});
                dt.Rows.Add(new object[] {6, "5555", "USA"});
                Dictionary<string, string> dict = dt.AsEnumerable()
                    .GroupBy(x => x.Field<string>("CID"), y => y.Field<string>("CountryName"))
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
    }
