    public abstract class Root<TChild> : IRoot<TChild>
    {
        private List<TChild> _children = new List<TChild>();
        public IReadOnlyList<TChild> Children => _children;
        public void AddChild(TChild child)
        {
            _children.Add(child);
            SetChildsParent(child);
        }
        protected abstract void SetChildsParent(TChild child);
    }
    public class Leaf<TParent> : ILeaf<TParent>
    {
        public TParent Parent { get; internal set; }
    }
    public abstract class Node<TParent, TChild> : Root<TChild>, INode<TParent, TChild>
    {
        public TParent Parent { get; internal set; }
    }
