    public class ParentClass 
    {
        public List<ChildClass> Children;
        public void AddChild(ChildClass child)
        {
            Children.Add(child);
            // or something else, etc. 
        }
        // various stuff like making sure Children actually exists before AddChild is called
    }
    
    public class ChildClass 
    {
        public ParentClass Parent;
        public ChildClass(ParentClass parent)
        {
            Parent = parent;
            Parent.AddChild(this);
        }
    }
