    public static class MyExtension<T>
        {
            public static void MyForEach(this IEnumerable<T> collection, Action<T> action)
            {
                foreach (T item in collection)
                    action.Invoke(item);
            }
        }
