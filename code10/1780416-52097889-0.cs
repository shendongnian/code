    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication61
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Purchased Date", typeof(DateTime));
                dt.Columns.Add("Price", typeof(decimal));
                dt.Rows.Add(new object[] { "Item A",DateTime.Parse("11/5/2014"), 1000.00 });
                dt.Rows.Add(new object[] { "Item B",DateTime.Parse("2/20/2015"), 1000.00 });
                dt.Rows.Add(new object[] { "Item C",DateTime.Parse("4/5/2016"), 1000.00 });
                dt.Rows.Add(new object[] { "Item D",DateTime.Parse("8/5/2017"), 1000.00 });
                dt.Rows.Add(new object[] { "Item E",DateTime.Parse("9/3/2018"), 1000.00 });
                dt.Rows.Add(new object[] { "Item F",DateTime.Parse("1/5/2015"), 1000.00 });
                DateTime startDate = dt.AsEnumerable().Min(x => x.Field<DateTime>("Purchased Date"));
                DateTime startQuarter = new DateTime(startDate.Year, (3 * (startDate.Month / 3)) + 1, 1 );
                double depreciationRate = .99; //rate per quarter
                DateTime[] quarters = Enumerable.Range(0, (((DateTime.Now - startQuarter).Days) / 90) + 1).Select(x => startQuarter.AddMonths(3 * x)).ToArray();
                var depreciation = dt.AsEnumerable()
                    .Select(x => new
                    {
                        item = x.Field<string>("Name"),
                        depreciation = quarters
                            .Select(y => x.Field<DateTime>("Purchased Date") > y ? 0 : x.Field<decimal>("Price") *(decimal) Math.Pow(depreciationRate, ((y - x.Field<DateTime>("Purchased Date")).Days) / 90)).ToList()
                    })
                    .ToList();
            }
        }
    }
