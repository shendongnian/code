    public static class Extensions
    {
        public static IEnumerable<T> GetRecursively<T>(
          this IEnumerable<T> collection, Func<T, IEnumerable> selector)
        {
            foreach (var item in collection)
            {
                yield return item;
                IEnumerable<T> children = selector(item).OfType<T>()
                   .GetRecursively(selector);
                foreach (var child in children)
                {
                    yield return child;
                }
            }
        }
    }
