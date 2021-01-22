    public static void IgnorantForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
            {
                try
                {
                    action(item);
                }
                catch
                {
                    
                }
            }
        }
