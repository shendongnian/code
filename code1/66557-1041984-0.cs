        public static IEnumerable<DataRow> EnumerateRows(this DataTable table)
        {
            foreach (var row in table.Rows)
            {
                yield return row;
            }
        }
