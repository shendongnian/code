    public static class CustomLINQtoDataSetMethods {
        public static DataTable CopyToDataTable<T>(this IEnumerable<T> source) {
            return new ObjectShredder<T>().Shred(source, null, null);
        }
    
        public static DataTable CopyToDataTable<T>(this IEnumerable<T> source,
                                                    DataTable table, LoadOption? options) {
            return new ObjectShredder<T>().Shred(source, table, options);
        }  
    }
