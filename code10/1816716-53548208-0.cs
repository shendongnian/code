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
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("CustName", typeof(string));
                dt.Columns.Add("201501", typeof(decimal));
                dt.Columns.Add("201502", typeof(decimal));
                dt.Columns.Add("201503", typeof(decimal));
                dt.Columns.Add("201504", typeof(decimal));
                dt.Rows.Add(new object[] {32, "CustOne",100.00, 200.00, 400.00, 700.00});
                dt.Rows.Add(new object[] {56, "CustTwo", 100.00 , 200.00 , 300.00, 500.00});
                dt.Rows.Add(new object[] {89, "CustThree", 222.22 ,333.33, 444.44, 555.55});
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("ID", typeof(int));
                dt2.Columns.Add("CustName", typeof(string));
                for (int i = 2; i < dt.Columns.Count - 1; i++)
                {
                    dt2.Columns.Add("PerDiff" + (i).ToString("0#"), typeof(decimal));
                }
                foreach (DataRow row in dt.AsEnumerable())
                {
                    DataRow newRow = dt2.Rows.Add();
                    newRow["ID"] = row.Field<int?>("ID");
                    newRow["CustName"] = row.Field<string>("CustName");
                    for (int i = 2; i < dt.Columns.Count - 1; i++)
                    {
                        newRow[i] = row.Field<decimal?>(i + 1) / row.Field<decimal?>(i);
                    }
                }
                
            }
        }
    }
