    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication65
    {
        class Program
        {
            static DataTable dt = null;
            static void Main(string[] args)
            {
                dt = new DataTable();
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("Per_Router" , typeof(int));
                dt.Columns.Add("Prod_No", typeof(int));
                dt.Columns.Add("Rout_No", typeof(int));
                dt.Rows.Add(new object[] {null, 1, 81235, 77976});
                dt.Rows.Add(new object[] {null, 1, 67907, 77976});
                dt.Rows.Add(new object[] {null, 1, 66772, 77976 });
                dt.Rows.Add(new object[] {21202, 2, null, 77976 });
                dt.Rows.Add(new object[] {41978, 1, null, 77976 });
                dt.Rows.Add(new object[] {41979, 1, null, 77976});
                dt.Rows.Add(new object[] {20373, 11, null, 81253   });
                dt.Rows.Add(new object[] {20377, 1, null, 81253   });
                dt.Rows.Add(new object[] {20379, 1, null, 81253   });
                dt.Rows.Add(new object[] {20388, 4, null, 81253});
                dt.Rows.Add(new object[] {20265, 1, null, 81235});
                dt.Rows.Add(new object[] {28957, 1, null, 81235});
                dt.Rows.Add(new object[] {null, 1, 53755, 81235});
                dt.Rows.Add(new object[] {null, 1, 53788, 81235});
                dt.Rows.Add(new object[] {null, 1, 59516, 81235});
                Console.WriteLine("Id    Per_Router       Prod_No  Rout_No");
                ParseTableRecursive(null);
                Console.ReadLine();
            }
            static void ParseTableRecursive(int? parent)
            {
                List<DataRow> group = dt.AsEnumerable().Where(x => x.Field<int?>("Prod_No") == parent).ToList();
                if(group.Count > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Sub-components of {0}", parent == null ? "NULL" : parent.ToString());
                    Console.WriteLine();
                    foreach (DataRow row in group)
                    {
                        Console.WriteLine("{0:5}     {1:5}     {2:5}     {3:5}",
                            row.Field<int?>("Id") == null ? "NULL" : row.Field<int?>("Id").ToString(),
                            row.Field<int?>("Per_Router") == null ? "NULL" : row.Field<int?>("Per_Router").ToString(),
                            row.Field<int?>("Prod_No") == null ? "NULL" : row.Field<int?>("Prod_No").ToString(),
                            row.Field<int?>("Rout_No") == null ? "NULL" : row.Field<int?>("Rout_No").ToString()
                        );
                        
                    }
                    foreach (int? child in group.Select(x => x.Field<int?>("Rout_No")).Distinct())
                    {
                        ParseTableRecursive(child);
                    }
                }
            }
        }
    }
