      public static void Iterate<T>(this IEnumerable<T> enumerable, Action<T> callback)
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException("enumerable");
            }
    
            IterateHelper(enumerable, (x, i) => callback(x));
        }
    
        public static void Iterate<T>(this IEnumerable<T> enumerable, Action<T,int> callback)
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException("enumerable");
            }
    
            IterateHelper(enumerable, callback);
        }
    
        private static void IterateHelper<T>(this IEnumerable<T> enumerable, Action<T,int> callback)
        {
            int count = 0;
            foreach (var cur in enumerable)
            {
                callback(cur, count);
                count++;
            }
        }
