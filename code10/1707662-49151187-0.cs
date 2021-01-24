    public class Parent
    {
        public List<Child> Children = new List<Child>();
        public void AddChild(string childArg1)
        {
            Children.Add(new Child(this, childArg1);
        }
    }
    public class Child
    {
        public Parent Parent { get; private set; }
        public Child(Parent parent, string childArg1)
        {
            Parent = parent;
        }
    }
