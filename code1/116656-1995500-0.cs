    using System.Data;
    namespace DtCheck
    {
        class Program
        {
            static void Main()
            {
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("a", typeof(string));
                dt1.Columns.Add("b", typeof(float));
                dt1.Columns.Add("c", typeof(float));
                dt1.Rows.Add("xyz", 0.0, 0.0);
                DataTable dt2;
                dt2 = dt1.Clone();
                dt2.Merge(dt1, true);
                dt1.Rows.Add("mnp", 4.5, 8.9);
 
                dt2.Merge(dt1, true);
            }
        }
    }
