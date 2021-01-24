    DataTable table = new DataTable();
            table.Columns.Add("Code", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("Amount", typeof(int));
            table.Columns.Add("Unit", typeof(string));
            table.Columns.Add("Prize", typeof(double));
            // Here we add five DataRows.
            table.Rows.Add("0001", "papaya", "100", "KG", 75);
            table.Rows.Add("0002", "mango", "50", "KG", 50);
            table.Rows.Add("0001", "papaya", "200", "KG", 75);
            var rows = table.AsEnumerable().GroupBy(row => row.Field<string>("Code")).Select(g =>
            {
                var row = table.NewRow();
                row["Code"] = g.Key;
                row["Description"] = row.Field<string>("Description");
                row["Amount"] = g.Sum(y => y.Field<int>("Amount"));
                row["Unit"] = row.Field<string>("Unit");
                row["Prize"] = row.Field<double?>("Prize") == null ? 0 : row.Field<double>("Prize");
                return row;
            }).CopyToDataTable();
            foreach (var data1 in rows.Rows)
            {
                Console.WriteLine(data1.ToString());
            }
