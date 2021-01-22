    class ParentClass
    {
        private List<ChildClass> _children;
    
        public virtual ReadOnlyCollection<ChildClass> Children
        {
            get
            {
                return _children.AsReadOnly();
            }
        }
    
        public virtual ChildClass CreateChild()
        {
            // Set parent in child class constructor
            ChildClass newChild = new ChildClass(this);
    
            _children.Add(newChild);
    
            return newChild;
        }
    }
