    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication97
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Title", typeof(string));
                dt.Columns.Add("Category", typeof(string));
                dt.Columns.Add("SubCategory", typeof(string));
                dt.Columns.Add("Value", typeof(int));
                dt.Rows.Add(new object[] {1, "Part-1", "CatX", "A", 100});
                dt.Rows.Add(new object[] {2, "Part-1", "CatX", "B", 0});
                dt.Rows.Add(new object[] {3, "Part-1", "CatX", "C", 50});
                dt.Rows.Add(new object[] {4, "Part-1", "CatY", "A", 100});
                dt.Rows.Add(new object[] {5, "Part-1", "CatY", "B", 0});
                dt.Rows.Add(new object[] {6, "Part-1", "CatY", "C", 100});
                dt.Rows.Add(new object[] {7, "Part-2", "CatM", "A", 30});
                dt.Rows.Add(new object[] {8, "Part-2", "CatM", "B", 10});
                dt.Rows.Add(new object[] {9, "Part-2", "CatM", "C", 100});
                dt.Rows.Add(new object[] {10, "Part-2", "CatN", "A", 50});
                dt.Rows.Add(new object[] {11, "Part-2", "CatN", "B", 10});
                dt.Rows.Add(new object[] {12, "Part-2", "CatN", "C", 80});
                var groups = dt.AsEnumerable().GroupBy(x => new { title = x.Field<string>("Title"), subcategory = x.Field<string>("SubCategory") }).ToList();
                var totals = groups.Select(x => new {title = x.Key.title, subCategory = x.Key.subcategory, average = x.Average(y => y.Field<int>("Value"))}).ToList();
            }
        }
    }
