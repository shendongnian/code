      public class TreeNode<T> : IEnumerable<TreeNode<T>>
        {
    
            public T Data { get; set; }
            public TreeNode<T> Parent { get; set; }
            public ICollection<TreeNode<T>> Children { get; set; }
    
            public TreeNode(T data)
            {
                this.Data = data;
                this.Children = new LinkedList<TreeNode<T>>();
            }
    
            public TreeNode<T> AddChild(T child)
            {
                TreeNode<T> childNode = new TreeNode<T>(child) { Parent = this };
                this.Children.Add(childNode);
                return childNode;
            }
    
            public IEnumerator<TreeNode<T>> GetEnumerator()
            {
                throw new NotImplementedException();
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return (IEnumerator)GetEnumerator();
            }
        }
        public class TreeNodeEnum<T> : IEnumerator<TreeNode<T>>
        {
    
            int position = -1;
            public List<TreeNode<T>> Nodes { get; set; }
    
            public TreeNode<T> Current
            {
                get
                {
                    try
                    {
                        return Nodes[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
    
    
            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }
    
    
            public TreeNodeEnum(List<TreeNode<T>> nodes)
            {
                Nodes = nodes;
            }
    
            public void Dispose()
            {
            }
    
            public bool MoveNext()
            {
                position++;
                return (position < Nodes.Count);
            }
    
            public void Reset()
            {
                position = -1;
            }
        }
