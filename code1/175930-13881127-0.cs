     public static class Extensions
        {
            public static void Action<T>(this IEnumerable<T> list, Action<T> action)
            {
                foreach (T element in list) 
                {
                    action.Invoke(element);
                }
            }
        }
