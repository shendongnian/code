            var tbl = new DataTable("MyData");
            using (var fs = new StreamReader(@"C:\Temp\test.csv"))
            {
                var data = fs.ReadToEnd();
                var rows = data.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                var cnt = 0;
                foreach (var row in rows)
                {
                    var cells = row.Split(new string[] { "\",\"" }, StringSplitOptions.None);
                    if (cnt == 0) foreach (var cell in cells)
                        tbl.Columns.Add(new DataColumn(cell));
                    else
                    {
                        var dataRow = tbl.NewRow();
                        dataRow.ItemArray = cells;
                        tbl.Rows.Add(dataRow);
                    }
                    cnt++;
                }
            }
