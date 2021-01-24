    public static class Ext {
        public static IEnumerable<string> NonPrimaryKeyColumnNames(this DataTable aTable) => aTable.ColumnNames().Where(n => n != "PrimaryKey");
    
        public static IEnumerable<DataColumn> DataColumns(this DataTable aTable) => aTable.Columns.Cast<DataColumn>();
        public static IEnumerable<string> ColumnNames(this DataTable aTable) => aTable.DataColumns().Select(dc => dc.ColumnName);
        public static void CopyColumnValues(this DataRow dest, DataRow src, IEnumerable<string> colNames) {
            foreach (var colName in colNames)
                dest[colName] = src[colName];
        }
        public static void PushRange<T>(this Stack<T> s, IEnumerable<T> Ts) => Ts.ForEach(aT => s.Push(aT));
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action) {
            foreach (var s in source)
                action(s);
        }
    }
