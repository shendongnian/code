    public class ChildCollection<TChild> : IEnumerable<TChild> 
        where TChild : ChildCollection<TChild>.Child
    {
        private readonly List<TChild> childCollection = new List<TChild>();
    
        private void Add(TChild child) => this.childCollection.Add(child);
    
        public IEnumerator<TChild> GetEnumerator() => this.childCollection.GetEnumerator();
    
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
        public abstract class Child
        {
            private readonly ChildCollection<TChild> childCollection;
        
            protected Child(ChildCollection<TChild> childCollection)
            {
                this.childCollection = childCollection;
                childCollection.Add((TChild)this);
            }
        }
    }
