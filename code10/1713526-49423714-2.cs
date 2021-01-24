    using System;
    using System.Data;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
        static void Main(string[] args)
        {
            var dt = FillUpTestTable();
            DumpDataTable(dt);
            DataTable newDt = dt.AsEnumerable()
                .GroupBy(r => r.Field<int>("tid"))
                .Select(g => {
                    var row = dt.NewRow();
                    row["tid"] = g.Key;
                    row["code"] = g.First(r => r["code"] != null).Field<int>("code");
                    row["pNameLocal"] = g.First(r => r["pNameLocal"] != null).Field<string>("pNameLocal");
                    row["qty"] = g.Sum(r => r.Field<int>("qty"));
                    row["price"] = g.Sum(r => r.Field<double>("price"));
                    return row;
                }).CopyToDataTable();
            Console.WriteLine();
            Console.WriteLine("Result: ");
            Console.WriteLine();
            DumpDataTable(newDt);
            Console.ReadLine();
        }
        private static DataTable FillUpTestTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("tid", typeof(int));
            dt.Columns.Add("code", typeof(int));
            dt.Columns.Add("pNameLocal", typeof(string));
            dt.Columns.Add("qty", typeof(int));
            dt.Columns.Add("price", typeof(double));
            dt.Rows.Add(1, 101, 101, "some_local_name", 2, 20.36);
            dt.Rows.Add(2, 102, 202, "some_local_name", 2, 15.30);
            dt.Rows.Add(3, 102, 202, "some_local_name", 2, 15.30);
            dt.Rows.Add(4, 102, 202, "some_local_name", 2, 10.00);
            dt.Rows.Add(5, 102, 202, "some_local_name", 2, 15.30);
            dt.Rows.Add(6, 102, 202, "some_local_name2", 1, 15.30);
            dt.Rows.Add(7, 103, 202, "some_local_name", 2, 15.30);
            dt.Rows.Add(8, 104, 202, "some_local_name", 2, 05.00);
            dt.Rows.Add(9, 105, 202, "some_local_name", 2, 07.01);
            return dt;
        }
        private static void DumpDataTable(DataTable newDt)
        {
            foreach (DataRow dataRow in newDt.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.Write(item + "   | ");
                }
                Console.WriteLine();
            }
        }
    }
}
