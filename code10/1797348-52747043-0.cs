    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("ResponseHeaderId", typeof (string));
                dt1.Columns.Add("DateTime", typeof (DateTime));
                dt1.Rows.Add(new object[] { "0e24cf96-81eb-2122-7e4a-0d200474692f", DateTime.Parse("06/10/2018 11:15:59") });
                dt1.Rows.Add(new object[] { "0e24cf96-81eb-2122-7e4a-0d2004746930", DateTime.Parse("05/10/2018 11:15:59") });
                dt1.Rows.Add(new object[] { "0e24cf96-81eb-2122-7e4a-0d2004746931", DateTime.Parse("04/10/2018 11:15:59") });
                dt1.Rows.Add(new object[] { "0e24cf96-81eb-2122-7e4a-0d2004746932", DateTime.Parse("03/10/2017 11:15:59") });
                dt1.Rows.Add(new object[] { "0e24cf96-81eb-2122-7e4a-0d2004746933", DateTime.Parse("02/10/2017 11:15:59") });
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("ResponseDataId", typeof (string));
                dt2.Columns.Add("ResponseHeaderId", typeof (string));
                dt2.Columns.Add("Response", typeof (int));
                dt2.Rows.Add(new object[] { "41c831f1-0adc-2bd5-053e-00406fa526b6","0e24cf96-81eb-2122-7e4a-0d200474692f", 1 });  
                dt2.Rows.Add(new object[] { "78967068-82a6-4098-ba35-03211a923f46","0e24cf96-81eb-2122-7e4a-0d200474692f", 2 });
                dt2.Rows.Add(new object[] { "854bc8a6-5877-a6fb-9072-00e358323350","0e24cf96-81eb-2122-7e4a-0d2004746930", 2 });
                dt2.Rows.Add(new object[] { "fe2a667d-ca0e-49a6-b330-f4d4232bfe89","0e24cf96-81eb-2122-7e4a-0d2004746931", 3 });
                dt2.Rows.Add(new object[] { "30f0270e-3e69-3408-7add-02a85f4b9aeb","0e24cf96-81eb-2122-7e4a-0d2004746932", 1 });
                dt2.Rows.Add(new object[] { "30f0270e-3e69-3408-7add-02a85f4b9aeb","0e24cf96-81eb-2122-7e4a-0d2004746933", 1 });
                var join = (from d1 in dt1.AsEnumerable()
                            join d2 in dt2.AsEnumerable() on d1.Field<string>("ResponseHeaderId") equals d2.Field<string>("ResponseHeaderId")
                            select new { d1 = d1, d2 = d2 })
                            .OrderByDescending(x => x.d1.Field<DateTime>("DateTime"))
                           .GroupBy(x => new { year = x.d1.Field<DateTime>("DateTime").Year, month = x.d1.Field<DateTime>("DateTime").ToString("MMMM") })
                           .Select(x => new { year = x.Key.year, month = x.Key.month, total = x.Select(y => y.d2.Field<int>("Response")).Sum()})
                           .ToList();
            }
        }
     
    }
