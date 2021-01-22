    public static class ReorderByExt
    {
        public static IList<T> ReorderBy<T>( this IList<T> list, IList<int> order )
        {
            return new DynamicallyOrderedList( list, order );
        }
    }
