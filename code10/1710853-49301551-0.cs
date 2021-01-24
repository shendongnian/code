    public static class DataTableExtensions
    {
        public static T GetValueOrDefault<T>(this DataRow row, string columnName)
        {
            return row.GetValueOrDefault<T>(columnName, default(T));
        }
        
        public static T GetValueOrDefault<T>(this DataRow row, string columnName, T defaultValue)
        {
            return row.Table.Columns[ColumnName] != null && 
                   row[columnName] != DbNull.Value && 
                   row[columnName] is T ? (T)row[columnName] : defaultValue;
        }
    }
