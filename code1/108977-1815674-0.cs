    public static IEnumerable<T> GetRecursively<T>(this IEnumerable collection,
        Func<T, IEnumerable> selector,
        Func<T, bool> predicate)
    {
        foreach (var item in collection.OfType<T>())
        {
            if(!predicate(item)) continue;
            yield return item;
            IEnumerable<T> children = selector(item).GetRecursively(selector, predicate);
            foreach (var child in children)
            {
                yield return child;
            }
        }
    }
    var theNodes = treeView1.Nodes.GetNodesRecursively(
        x => x.Nodes,
        n => n.Text.Contains("1")).ToList();
