    public static class Extensions
    {
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> items, 
            Func<T, T, bool> equals, Func<T,int> hashCode)
        {
            return items.Distinct(new DelegateComparer<T>(equals, hashCode));    
        }
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> items,
            Func<T, T, bool> equals)
        {
            return items.Distinct(new DelegateComparer<T>(equals,null));
        }
    }
