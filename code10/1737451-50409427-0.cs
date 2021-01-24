    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication45
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("MARKETID", typeof(int));
                dt.Columns.Add("CommodityID", typeof(int));
                dt.Columns.Add("CurrencyID", typeof(int));
                dt.Columns.Add("PriceValue", typeof(decimal));
                dt.Columns.Add("Year", typeof(int));
                dt.Columns.Add("Month", typeof(int));
                //ID | MarketID | CommodityID | CurrencyID | PriceValue | Year | Month
                dt.Rows.Add(new object[] {1  , 100 , 30 , 15 , 3.465 , 2018 , 03});
                dt.Rows.Add(new object[] {2  , 100 , 30 , 15 , 2.372 , 2018 , 04});
                dt.Rows.Add(new object[] {3  , 100 , 32 , 15 , 1.431 , 2018 , 02});
                dt.Rows.Add(new object[] {4  , 100 , 32 , 15 , 1.855 , 2018 , 03});
                dt.Rows.Add(new object[] {5  , 100 , 32 , 15 , 2.065 , 2018 , 04});
                dt.Rows.Add(new object[] {6  , 101 , 30 , 15 , 7.732 , 2018 , 03});
                dt.Rows.Add(new object[] {7  , 101 , 30 , 15 , 8.978 , 2018 , 04});
                dt.Rows.Add(new object[] {8  , 101 , 32 , 15 , 4.601 , 2018 , 02});
                dt.Rows.Add(new object[] {9  , 101 , 32 , 18 , 0.138 , 2017 , 12});
                dt.Rows.Add(new object[] {10 , 101 , 32 , 18 , 0.165 , 2018 , 03});
                dt.Rows.Add(new object[] { 11, 101, 32, 18, 0.202, 2018, 04 });
                List<DataRow> results = dt.AsEnumerable()
                    .OrderByDescending(x => new DateTime(x.Field<int>("Year"), x.Field<int>("Month"), 1))
                    .GroupBy(x => new { market = x.Field<int>("MarketID"), commodity = x.Field<int>("CommodityID"), currency = x.Field<int>("CurrencyID") })
                    .Select(x => x.First())
                    .ToList();
            }
        }
    }
