    public class Parent
    {
        public List<Parent> ListOf = new List<Parent>();
    }
    public class Child : Parent
    {
        public new List<Child> ListOf = new List<Child>();
    }
