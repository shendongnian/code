    public class MyClass
    {
        public MyClass Parent { get; private set; }
        
        private List<MyClass> _children = new List<MyClass>();
        public IEnumerable<MyClass> Children
        {
            get
            {
                // Using an iterator so that client code can't access the underlying list
                foreach(var child in _children)
                {
                    yield return child;
                }
            }
        }
    
        public void AddChild(MyClass child)
        {
            child.Parent = this;
            _children.Add(child);
        }
    
        public void RemoveChild(MyClass child)
        {
            _children.Remove(child);
            child.Parent = null;
        }
    }
