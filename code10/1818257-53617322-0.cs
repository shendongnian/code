    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication87
    {
        class Program
        {
           static void Main(string[] args)
            {
               DataTable dt1 = new DataTable();
               dt1.Columns.Add("CategoryID", typeof(int));
               dt1.Columns.Add("ProductID", typeof(int));
               dt1.Rows.Add(new object[] { 1,4});
               dt1.Rows.Add(new object[] { 1,5});
               dt1.Rows.Add(new object[] { 2,7});
               DataTable dt2 = new DataTable();
               dt2.Columns.Add("CategoryID", typeof(int));
               dt2.Columns.Add("ProductID", typeof(int));
               dt2.Rows.Add(new object[] { 1, 4 });
               dt2.Rows.Add(new object[] { 2, 7 });
               var lessRows = (from a in dt1.AsEnumerable().GroupBy(x => x.Field<int>("CategoryID"))
                                         join b in dt2.AsEnumerable().GroupBy(x => x.Field<int>("CategoryID")) on a.Key equals b.Key
                                         select new { a = a, b = b })
                                         .Where(x => x.a.Count() > x.b.Count())
                                         .ToList();
     
            }
        }
      
     
    }
