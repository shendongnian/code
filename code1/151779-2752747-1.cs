    public static class Enumerable
    {
        public static int Count<T>(this IEnumerable<T> source)
        {
            dynamic d = source;
            return CountImpl(d);
        }
    
        private static int CountImpl<T>(ICollection<T> collection)
        {
            return collection.Count;
        }
    
        private static int CountImpl(ICollection collection)
        {
            return collection.Count;
        }
    
        private static int CountImpl<T>(string text)
        {
            return text.Length;
        }
        
        private static int CountImpl<T>(IEnumerable<T> source)
        {
            // Fallback
            int count = 0;
            foreach (T t in source)
            {
                count++;
            }
            return count;
        }
    }
