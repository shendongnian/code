    public static class Extensions
    {
        public static IList<R> TransformTree<T, R>(this IEnumerable<T> collection,
            Func<T, IEnumerable<T>> entitySelector,
            Func<R, IList<R>> pocoSelector,
            Func<T, R> transformer)
        {
            var transformedList = new List<R>();
            var stack = new Stack<IEnumerable<T>>();
            var parents = new Dictionary<IEnumerable<T>, R>();
            stack.Push(collection);
            while (stack.Count > 0)
            {
                IEnumerable<T> items = stack.Pop();
                R transformedParent;
                IList<R> parentChildren = parents.TryGetValue(items, out transformedParent)
                                              ? pocoSelector(transformedParent)
                                              : transformedList;
                foreach (var item in items)
                {
                    R transformedItem = transformer(item);
                    parentChildren.Add(transformedItem);
                    IEnumerable<T> children = entitySelector(item);
                    stack.Push(children);
                    parents.Add(children, transformedItem);
                }
            }
            return transformedList;
        }
    }
