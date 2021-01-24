    public static class Extensions
    {
        public static IEnumerable<object> FlattenArrays(this IEnumerable source)
        {
            foreach (var item in source)
            {
                if (item is IEnumerable inner
                    && !(item is string))
                {
                    foreach (var innerItem in inner.FlattenArrays())
                    {
                        yield return innerItem;
                    }
                }
                yield return item;
            }
        }
    }
