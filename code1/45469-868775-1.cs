        public static IList<T> ConvertTo<T>(DataTable table)
        {
            if (table == null)
                return null;
            List<DataRow> rows = new List<DataRow>();
            foreach (DataRow row in table.Rows)
                rows.Add(row);
            return ConvertTo<T>(rows);
        }
