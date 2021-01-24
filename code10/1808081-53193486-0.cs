    public interface IParent
    {
        String World { get; protected set; }
    }
    public class Parent : IParent
    {
        public String World { get; protected set; }
        public Parent() { World = "Hello World"; }
    }
    public class Children : Parent
    {
        public Children() { World = "World"; }
    }
