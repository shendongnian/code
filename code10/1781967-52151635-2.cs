    class BaseTreeData<T> where T : BaseTreeData<T>
    {
        public bool IsChecked { get; set; }
        public T Parent { get; set; }
        public List<T> Children { get; set; }
        public BaseTreeData()
        {
            Children = new List<T>();
        }
        public IEnumerable<T> GetAncestors()
        {
            if (Parent == null)
                yield break;
            T relative = Parent;
            while (relative != null)
            {
                yield return relative;
                relative = relative.Parent;
            }
        }
        public IEnumerable<T> GetDescendants()
        {
            var nodes = new Stack<T>();
            nodes.Push(this as T);
            while (nodes.Any())
            {
                var current = nodes.Pop();
                yield return current;
                foreach (var childNode in current.Children)
                    nodes.Push(childNode);
            }
        }
    }
    class TreeData : BaseTreeData<TreeData>
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
