            DataTable table = new DataTable();
            DataColumn val = table.Columns.Add("Value", typeof(string));
            table.Rows.Add("abc");
            table.Rows.Add("defgh");
            table.Rows.Add("i");
            table.Rows.Add("jklm");
            // sort logic:
            DataColumn sort = table.Columns.Add("Sort", typeof(int));
            foreach (DataRow row in table.Rows) {
                row[sort] = ((string)row[val]).Length;
            }
            DataView view = new DataView(table);
            view.Sort = "Sort";
            foreach (DataRowView row in view) {
                Console.WriteLine(row.Row[val]);
            }
