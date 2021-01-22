    public class ChildCollection<TParent, TChild> : IEnumerable<TChild> 
        where TChild : ChildCollection<TParent, TChild>.Child
    {
        private readonly List<TChild> childCollection = new List<TChild>();
    
        public TParent Parent { get; }
    
        public ChildCollection(TParent parent)
        {
            Parent = parent;
        }
    
        private void Add(TChild child) => this.childCollection.Add(child);
    
        public IEnumerator<TChild> GetEnumerator() => this.childCollection.ToList().GetEnumerator();
    
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
        public abstract class Child
        {
            private readonly ChildCollection<TParent, TChild> childCollection;
    
            public TParent Parent => this.childCollection.Parent;
    
            protected Child(ChildCollection<TParent, TChild> childCollection)
            {
                this.childCollection = childCollection;
                childCollection.Add((TChild)this);
            }
        }
    }
