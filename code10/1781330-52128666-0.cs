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
                dt.Columns.Add("CustomerID", typeof(int));
                dt.Columns.Add("CurrencyID", typeof(int));
                dt.Columns.Add("Amount", typeof(decimal));
                dt.Rows.Add(new object[] {1000, 1, 100.00});
                dt.Rows.Add(new object[] {1000,1,200.00});
                dt.Rows.Add(new object[] {1001,2,100.00});
                dt.Rows.Add(new object[] {1001,2,200.00});
                dt.Rows.Add(new object[] {1002,1,100.00});
                dt.Rows.Add(new object[] {1002,2,200.00});
                dt.Rows.Add(new object[] {1002,2,100.00});
                dt.Rows.Add(new object[] {1003,1,100.00});
                dt.Rows.Add(new object[] {1003,2,200.00});
               Dictionary<int,Dictionary<int, decimal>> dict = dt.AsEnumerable()
                    .GroupBy(x => x.Field<int>("CustomerID"), y => y)
                        .ToDictionary(x => x.Key, y => y
                           .GroupBy(a => a.Field<int>("CurrencyID"), b => b.Field<decimal>("Amount"))
                           .ToDictionary(a => a.Key, b => b.Sum(c => c)));
                    
            }
        }
    }
