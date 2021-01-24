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
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(long));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Value", typeof(string));
                dt.Rows.Add(new object[] {1, "abc", "mno"});
                dt.Rows.Add(new object[] {1, "def", "mnp"});
                dt.Rows.Add(new object[] {1, "def", "mnq"});
                dt.Rows.Add(new object[] {2, "abc", "mnr"});
                dt.Rows.Add(new object[] {2, "abd", "mns"});
                dt.Rows.Add(new object[] {3, "abe", "mnt"});
                dt.Rows.Add(new object[] {3, "abf", "mnu"});
                dt.Rows.Add(new object[] {4, "abc", "mnv"});
                dt.Rows.Add(new object[] {4, "ade", "mnw"});
                Dictionary<long, Dictionary<string,string>> dict = dt.AsEnumerable()
                    .GroupBy(x => x.Field<long>("ID"), y => y)
                    .ToDictionary(x => x.Key, y => y
                        .GroupBy(a => a.Field<string>("Name"), b => b.Field<string>("Value"))
                        .ToDictionary(a => a.Key, b => b.FirstOrDefault())
                    );
            }
        }
    }
