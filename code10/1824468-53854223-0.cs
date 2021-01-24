    public class Parent 
    {
        public Guid Id { get; set; }
    
        private ICollection<Child> children;
        public virtual ICollection<Child> Children { get => children; set => children = value; }
    
        public void Add(Child child)
        {
            // use the backing field directly
            if (children == null) children = new HashSet<Child>();
            children.Add(child); 
        }
    }
