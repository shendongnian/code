    public static class EnumerableExtensions
    {
        public static IEnumerable<T> SelectDeep<T>(
            this IEnumerable<T> source, Func<T, IEnumerable<T>> selector)
        {
            foreach (T item in source)
            {
                yield return item;
                foreach (T subItem in SelectDeep(selector(item),selector))
                {
                    yield return subItem;
                }
            }
        }
    }
    public static class NodeExtensions
    {
        public static IEnumerable<Node> Descendents(this Node node)
        {
            if (node == null) throw new ArgumentNullException("node");
            return node.Children.SelectDeep(n => n.Children);
        }
    }
