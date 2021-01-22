    public class Parent
    {
        public ChildCollection<Parent, Child> ChildCollection { get; }
        public Parent()
        {
            ChildCollection = new ChildCollection<Parent, Child>(this);
        }
    }
    
    public class Child : Child<Parent, Child>
    {
       public Child(ChildCollection<Parent, Child> ChildCollection) : base(ChildCollection)
       {
       }
    }
