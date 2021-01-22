    static class Extensions
    {        
    
        public static IEnumerable<T> Duplicates<T>(this IEnumerable<T> input)
        {
            HashSet<T> hash = new HashSet<T>();
            foreach (T item in input)
            {
                if (!hash.Contains(item))
                {
                    hash.Add(item);
                }
                else
                {
                    yield return item;
                }
            }
        }
    }
