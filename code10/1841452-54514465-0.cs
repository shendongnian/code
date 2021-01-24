    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication100
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("AdId", typeof(int));
                dt.Columns.Add("AdName", typeof(string));
                dt.Columns.Add("AdUrl", typeof(string));
                dt.Columns.Add("Credits", typeof (int));
                dt.Rows.Add(new object[] {1, "Ad1", "abc.com", 10});
                dt.Rows.Add(new object[] {2, "Ad2", "def.com", 40});
                dt.Rows.Add(new object[] {3, "Ad3", "fgi.com", 30});
                dt.Rows.Add(new object[] {4, "Ad4", "xyz.com", 40});
                Random rand = new Random();
                List<DataRow> randomRows = dt.AsEnumerable().Select(x => new { row = x, rand = rand.Next() }).OrderBy(x => x.rand).Select(x => x.row).ToList();
                DataTable dt2 = randomRows.CopyToDataTable();
            }
        }
    }
