    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    using System.Data;
    namespace ConsoleApplication100
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("TransactionId", typeof(int));
                dt.Columns.Add("TransactionDate", typeof(DateTime));
                dt.Columns.Add("TotalIncome", typeof(int));
                dt.Rows.Add(new object[] { 1, DateTime.Parse("2017-10-12"), 230 });
                dt.Rows.Add(new object[] { 2, DateTime.Parse("2017-11-10"), 400 });
                dt.Rows.Add(new object[] { 3, DateTime.Parse("2018-01-03"), 300 });
                dt.Rows.Add(new object[] { 4, DateTime.Parse("2018-10-05"), 500 });
                dt.Rows.Add(new object[] { 5, DateTime.Parse("2019-01-06"), 600 });
                dt.Rows.Add(new object[] { 6, DateTime.Parse("2019-02-10"), 200 });
                var results = dt.AsEnumerable()
                    .GroupBy(x => x.Field<DateTime>("TransactionDate").Year)
                    .Select(x => new { year = x.Key, total = x.Sum(y => y.Field<int>("TotalIncome")) })
                    .ToList();
            }
        }
    }
