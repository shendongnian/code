    public class Tree<T> where T : Tree<T>
    {
        T parent;
        List<T> children;
        public Tree(T parent)
        {
            this.parent = parent;
            this.children = new List<T>();
            if( parent!=null ) { parent.children.Add(this as T); }
        }
        public bool IsRoot { get { return parent == null; } }
        public bool IsLeaf { get { return children.Count == 0; } }
    }
