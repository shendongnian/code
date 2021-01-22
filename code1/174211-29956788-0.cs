        public static String ToCsv(DataTable dt, bool addHeaders)
        {
            var sb = new StringBuilder();
            //Add Header Header
            if (addHeaders)
            {
                for (var x = 0; x < dt.Columns.Count; x++)
                {
                    if (x != 0) sb.Append(",");
                    sb.Append(dt.Columns[x].ColumnName);
                }
                sb.AppendLine();
            }
            //Add Rows
            foreach (DataRow row in dt.Rows)
            {
                for (var x = 0; x < dt.Columns.Count; x++)
                {
                    if (x != 0) sb.Append(",");
                    sb.Append(row[dt.Columns[x]]);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
