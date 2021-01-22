    public class Tree<T> where T : Tree<T>
    {
        public T Parent { get; private set; }
        public List<T> Children { get; private set; }
        public Tree(T parent)
        {
            this.Parent = parent;
            this.Children = new List<T>();
            if(parent!=null) { parent.Children.Add(this); }
        }
        public bool IsRoot { get { return Parent == null; } }
        public bool IsLeaf { get { return Children.Count==0; } }
    }
