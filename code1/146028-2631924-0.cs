    public class Parent
    {
       public Parent()
       {
         _children = new List<Child>();
        }
       private IList<Child> _children;
       public IEnumerable<Child> Children
       {
         get
         {
           return _children;
         }
       }
    
       public void Add(Child child)
    {
        if (_children.Contains(child)) return;
        if (child.Parent != null && child.Parent !=this) throw new Exception ("bla bla bla");
        _children.Add(child);
        child.Parent = this;
    }
    
    public void Remove (Child child)
    {
       child.Parent = null;
       _children.Remove(child)
    {
    
    }
    
    public class Child
    {
      public Parent Parent
      {
         get { return _parent;}
         protected internal set { _parent = value;}
    }
