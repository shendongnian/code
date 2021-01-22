    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            DataSet ds = new DataSet();
            DataTable t1 = new DataTable();
            t1.Columns.Add(new DataColumn
                               {
                                   ColumnName = "ID",
                                   DataType = typeof (int),
                                   AutoIncrement = true
                               });
            t1.PrimaryKey = new [] { t1.Columns["ID"]};
            ds.Tables.Add(t1);
            DataTable t2 = new DataTable();
            t2.Columns.Add(new DataColumn
            {
                ColumnName = "ID",
                DataType = typeof(int),
                AutoIncrement = true
            });
            t2.Columns.Add("ParentID", typeof(int));
            t2.PrimaryKey = new[] { t2.Columns["ID"] };
            ds.Tables.Add(t2);
            sw.Reset();
            sw.Start();
            PopulateTables(t1, t2);
            sw.Stop();
            Console.WriteLine("Populating tables took {0} ms.", sw.ElapsedMilliseconds);
            Console.WriteLine();
            var list1 = from r1 in t1.AsEnumerable()
                       join r2 in t2.AsEnumerable()
                           on r1.Field<int>("ID") equals r2.Field<int>("ParentID")
                       where r1.Field<int>("ID") == 1
                       select r2;
            sw.Reset();
            sw.Start();
            int count = 0;
            foreach (DataRow r in list1)
            {
                count += r.Field<int>("ID");
            }
            sw.Stop();
            Console.WriteLine("count = {0}.", count);
            Console.WriteLine("Completed LINQ iteration in {0} ms.", sw.ElapsedMilliseconds);
            Console.WriteLine();
            sw.Reset();
            sw.Start();
            ds.Relations.Add(new DataRelation("FK_t2_t1", t1.Columns["ID"], t2.Columns["ParentID"]));
            sw.Stop();
            Console.WriteLine("Creating DataRelation took {0} ms.", sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            var list2 =
                from r1 in t1.AsEnumerable()
                from r2 in r1.GetChildRows("FK_t2_t1")
                where r1.Field<int>("ID") == 1
                select r2;
            count = 0;
            foreach (DataRow r in list2)
            {
                count += r.Field<int>("ID");
            }
            sw.Stop();
            Console.WriteLine("count = {0}.", count);
            Console.WriteLine("Completed LINQ iteration using nested query in {0} ms.", sw.ElapsedMilliseconds);
            Console.WriteLine();
            sw.Reset();
            sw.Start();
            DataRow parentRow = t1.Select("ID = 1")[0];
            count = 0;
            foreach (DataRow r in parentRow.GetChildRows("FK_t2_t1"))
            {
                count += r.Field<int>("ID");
            }
            sw.Stop();
            Console.WriteLine("count = {0}.", count);
            Console.WriteLine("Completed explicit iteration of child rows in {0} ms.", sw.ElapsedMilliseconds);
            Console.WriteLine();
            Console.ReadLine();
        }
        private static void PopulateTables(DataTable t1, DataTable t2)
        {
            for (int count1 = 0; count1 < 1000; count1++)
            {
                DataRow r1 = t1.NewRow();
                t1.Rows.Add(r1);
                for (int count2 = 0; count2 < 1000; count2++)
                {
                    DataRow r2 = t2.NewRow();
                    r2["ParentID"] = r1["ID"];
                    t2.Rows.Add(r2);
                }
            }
        }
    } 
