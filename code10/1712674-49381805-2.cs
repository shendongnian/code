    public static class MyExtensions
    {
        public static IQueryable<T> MyContains<T, TFilter>(
             this IQueryable<T> list, 
             TFilter x, 
             Expression<Func<T, bool>> filterFunc)
        {
            if (x == null)
            {
                return list;
            }
            return list.Where(filterFunc);
        }
    }
