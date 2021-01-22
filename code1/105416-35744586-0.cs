                var lines = new List<string>();
                string[] columnNames = dt.Columns.Cast<DataColumn>().
                                                  Select(column => column.ColumnName).
                                                  ToArray();
                var header = string.Join(",", columnNames);
                lines.Add(header);
                var valueLines = dt.AsEnumerable()
                                   .Select(row => string.Join(",", row.ItemArray));
                lines.AddRange(valueLines);
                File.WriteAllLines("excel.csv", lines);
