    public static class Helper
    {
        public static void MergeColumns(this DataTable t, string newColumn, params string[] columnsToMerge)
        {
            t.Columns.Add(newColumn, typeof(string));
    
            var sb = new StringBuilder();
    
            sb.Append("{0}, ");
            for (int i = 1; i < columnsToMerge.Length; ++i)
                sb.Append("{" + i.ToString() + "}");
    
            string format = sb.ToString();
    
            foreach(DataRow r in t.Rows)
                r[newColumn] = string.Format(format, columnsToMerge.Select(col => r[col]).ToArray() );
        }
    }
