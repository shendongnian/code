    public static class DataRowCollectionExtensions
    {
        public static IEnumerable<DataRow> AsEnumerable(this DataRowCollection source)
        {
            return source.Cast<DataRow>();
        }
        public static IEnumerable<TDataRow> AsEnumerable<TDataRow>(this DataRowCollection source) where TDataRow : DataRow
        {
            return source.Cast<TDataRow>();
        }
    }
