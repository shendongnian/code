        public static void DataTableToCsv(DataTable dt, string csvFile)
        {
            StringBuilder sb = new StringBuilder();
            var columnNames = dt.Columns.Cast<DataColumn>().Select(column => "\"" + column.ColumnName.Replace("\"", "\"\"") + "\"").ToArray();
            sb.AppendLine(string.Join(",", columnNames));
            foreach (DataRow row in dt.Rows)
            {
                var fields = row.ItemArray.Select(field => "\"" + field.ToString().Replace("\"", "\"\"") + "\"").ToArray();
                sb.AppendLine(string.Join(",", fields));
            }
            File.WriteAllText(csvFile, sb.ToString(), Encoding.Default);
        }
