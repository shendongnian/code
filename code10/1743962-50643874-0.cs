    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication48
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Gender", typeof(string));
                dt.Columns.Add("Age", typeof(int));
                dt.Columns.Add("Category", typeof(int));
                
                dt.Rows.Add(new object[] {"Male", 10, 2});
                dt.Rows.Add(new object[] {"Feale", 15, 1});
                dt.Rows.Add(new object[] {"Trans", 13, 3});
                dt.Rows.Add(new object[] {"Female", 10, 1});
                dt.Rows.Add(new object[] {"Male", 20, 2});
                DataTable dt1 = dt.AsEnumerable().Where(x => x.Field<string>("Gender") == "Male").CopyToDataTable();
                DataTable dt2 = dt.AsEnumerable().Where(x => x.Field<string>("Gender") == "Feale").CopyToDataTable();
                DataTable dt3 = dt.AsEnumerable().Where(x => x.Field<string>("Gender") == "Trans").CopyToDataTable();
     
            }
        }
    }
