    public static class DataRowCollectionExtensions
    {
        public static IEnumerable<DataRow> AsEnumerable(this DataRowCollection source)
        {
            return source.Cast<DataRow>();
        }
    }
