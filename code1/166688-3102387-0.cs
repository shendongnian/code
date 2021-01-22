    public class Parent
    {
        List<Child> _children;
    
        public Child this[string name] 
        {
            get
            {
                return (_children ?? Enumerable.Empty<Child>())
                    .Where(c => c.Name == name)
                    .FirstOrDefault();
            }
        }
    }
