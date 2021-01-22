    class ChildClass
    {
        // Prevent unauthorized clients from overriding the Parent reference.
        public ParentClass Parent { get; internal set; }
        // ... other methods and properties ...
    }
    class ParentClass
    {
        private IList<ChildClass> _children;
        public void AddChild(ChildClass child)
        {
            _children.Add(child);
            child.Parent = this;
        }
        public RemoveChild(ChildClass child)
        {
            _children.Remove(child);
            child.Parent = null;
        }
        public IList<ChildClass> Children
        {
            get { return _children.AsReadOnly(); }
        }
    }
