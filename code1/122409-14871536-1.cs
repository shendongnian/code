    public static List<Node<TItem, TKey>> ToTree<TItem, TKey>(this IEnumerable<TItem> list, params Func<TItem, TKey>[] keySelectors)
    {
        return list.ToTree(0, keySelectors);
    }
    public static List<Node<TItem, TKey>> ToTree<TItem, TKey>(this IEnumerable<TItem> list, int nestingLevel, params Func<TItem, TKey>[] keySelectors)
    {
        Stack<Func<TItem, TKey>> stackSelectors = new Stack<Func<TItem, TKey>>(keySelectors.Reverse());
        if (stackSelectors.Any())
        {
            return list
                .GroupBy(stackSelectors.Pop())
                .Select(x => new Node<TItem, TKey>()
                {
                    Key = x.Key,
                    Level = nestingLevel,
                    Data = x.ToList(),
                    Children = x.ToList().ToTree(nestingLevel + 1, stackSelectors.ToArray())
                })
                .ToList();
            }
            else
            {
                return null;
            }
