            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("date", typeof(DateTime)));
            for (int i = 0; i < 10; i++)
            {
                DataRow row = dt.NewRow();
                row["date"] = DateTime.Now.AddDays(i);
                dt.Rows.Add(row);
            }
            foreach (var r in dt.AsEnumerable())
            {
                DateTime d = r.Field<DateTime>("date"); // no problems here!
                Console.Write(d.ToLongDateString());
            }
