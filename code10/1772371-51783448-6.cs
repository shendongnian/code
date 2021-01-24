    public static class ExtentionMethods
    {
        public static IQueryable<T> DoSpecificFilter<T>(
            this IQueryable<T> query, 
            Expression<Func<T, DateTime>> dateSelector, 
            DateTime filterValue, 
            bool blnTopLimit)
        {
            return query.Where(a => (blnTopLimit && dateSelector.Compile()(a) < filterValue)
                || (!blnTopLimit && dateSelector.Compile()(a) > filterValue));
        }
     }
