    var allNodes = yourTree.Roots.SelectMany(x => x.TraverseTree(y => y.Children));
    // ...
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> TraverseTree<T>(
            this T parentNode, Func<T, IEnumerable<T>> childNodesSelector)
        {
            yield return parentNode;
            IEnumerable<T> childNodes = childNodesSelector(parentNode);
            if (childNodes != null)
            {
                foreach (T childNode in
                    childNodes.SelectMany(x => x.TraverseTree(childNodesSelector)))
                {
                    yield return childNode;
                }
            }
        } 
    }
