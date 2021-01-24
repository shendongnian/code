           private StringWriter ExportDataTable(DataTable dt)
           {
                StringWriter writer = new StringWriter();
                string[] columnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
                writer.WriteLine(string.Join(",", columnNames));
                foreach(DataRow row in dt.AsEnumerable())
                {
                    writer.WriteLine(string.Join(",", row.ItemArray.Select(x => x.ToString())));
                }
                return writer;
            }
