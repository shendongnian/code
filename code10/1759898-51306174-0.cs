    public static class MyExtensions
    {
        public static bool IsNullOrHasExactlyOneMatching<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null) return true;
            bool found = false;
            foreach(T element in source)
            {
                if (!predicate(element)) continue;
                if (found) return false; // this is the second match!
                found = true;
            }
            return found; // one match found (or not)                                      
        }
    }
