        public static string ColumnIsNull(this System.Data.DataRow row, string colName, string defaultValue = "")
        {
            string val = defaultValue;
            if (row.Table.Columns.Contains(colName))
            {
                if (row[colName] != DBNull.Value)
                {
                    val = row[colName]?.ToString();
                }
            }
            return val;
        }
