    public static class MyExtentions 
    {
        public static IEnumerable<T> ToNullIfEmpty<T>(this IEnumerable<T> container) 
        {
            if(container == null || !container.Any())
                return null;
            else
                return container;            
        }
    }
