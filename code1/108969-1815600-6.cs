    public static class Extensions
    {
        public static IEnumerable<T> Get<T>(this IEnumerable collection,
            Func<T, IEnumerable> selector)
        {
            Stack<IEnumerable<T>> stack = new Stack<IEnumerable<T>>();
            stack.Push(collection.OfType<T>());
            while (stack.Count > 0)
            {
                IEnumerable<T> items = stack.Pop();
                foreach (var item in items)
                {
                    yield return item;
                    IEnumerable<T> children = selector(item).OfType<T>();
                    stack.Push(children);
                }
            }
        }
    }
