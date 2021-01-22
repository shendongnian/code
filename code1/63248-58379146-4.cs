    public class Parent
    {
        public ChildCollection<Child> ChildCollection { get; }
        public Parent()
        {
            ChildCollection = new ChildCollection<Child>();
        }
    }
    
    public class Child : ChildCollection<Child>.Child
    {
       public Child(ChildCollection<Child> childCollection) : base(childCollection)
       {
       }
    }
