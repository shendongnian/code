    public class CollectionOfChildren
    {
        public Child this[int index] { get; }
        public void Add(Child c) {
            c.Parent = this;
            innerCollection.Add(c);
        }
    }
    
    public class Child
    {
        public CollectionOfChildren Parent { get; internal set; }
    }
