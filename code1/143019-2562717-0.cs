    public static class Extensions
    { 
        public static IQueryable<T> Sort<T>(this IQueryable<T> query, string sortField, SortDirection direction) 
        { 
            if (direction == SortDirection.Ascending) 
                return query.OrderBy(s => s.GetType().GetProperty(sortField)); 
            return query.OrderByDescending(s => s.GetType().GetProperty(sortField)); 
     
        } 
    } 
