    public static class IEnumerablExtensions
            {
                //Will iterate the graph in depth first order
                public static IEnumerable<TResult> Select<TResult>(this IEnumerable collection, Func<Node, TResult> selector)
                {
                    foreach (var obj in collection)
                    {
                        var node = obj as Node;
                        if (node != null)
                        {
                            yield return selector(node);
                            foreach (var n in node.Nodes.Select(selector))
                            {
                               yield return n;
                            }
                        }
                    }
                }
        
            public static IEnumerable<Node> Where(this IEnumerable collection, Predicate<Node> pred)
            {
                foreach (var node in collection.Select(x => x)) //iterate the list in graph first order
                {
                    if (pred(node))
                        yield return node;
                }
            }
        }
