    public static void iter<T>(this IEnumerable<T> source, Action<T> act) 
            {
                foreach (var item in source)
                {
                    act(item);                
                }
            }
