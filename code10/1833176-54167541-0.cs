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
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("Column1", typeof(int));
                dt1.Rows.Add(1);
                dt1.Rows.Add(2);
                dt1.Rows.Add(3);
                dt1.Rows.Add(4);
                dt1.Rows.Add(5);
                dt1.Rows.Add(6);
                dt1.Rows.Add(7);
                dt1.Rows.Add(8);
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("Column1", typeof(int));
                dt2.Columns.Add("Column2", typeof(int));
                dt2.Columns.Add("Column3", typeof(int));
                dt2.Columns.Add("Column4", typeof(int));
                for (int i = 0; i < dt1.Rows.Count; i += 4)
                {
                    dt2.Rows.Add(new object[] { dt1.Rows[i].Field<int>("Column1"), dt1.Rows[i + 1].Field<int>("Column1"), dt1.Rows[i + 2].Field<int>("Column1"), dt1.Rows[i + 3].Field<int>("Column1") });
                }
            }
        }
    }
