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
                dt.Columns.Add("Group", typeof(string));
                dt.Columns.Add("Code", typeof(int));
                dt.Columns.Add("Value", typeof(int));
                dt.Columns["Value"].AllowDBNull = true;
                dt.Rows.Add(new object[] { "GroupA", 13,123});
                dt.Rows.Add(new object[] { "GroupA", 17,456});
                dt.Rows.Add(new object[] { "GroupB", 17,789});
                List<int> codes = dt.AsEnumerable().Select(x => x.Field<int>("Code")).Distinct().ToList();
                var groups = dt.AsEnumerable().GroupBy(x => x.Field<string>("Group")).ToList();
                foreach (var group in groups)
                {
                    foreach (int code in codes)
                    {
                        if (!group.Any(x => x.Field<int>("Code") == code))
                        {
                            dt.Rows.Add(new object[] { group.Key, code, DBNull.Value });
                        }
                    }
                }
            }
        }
    }
