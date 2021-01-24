    public interface IParent
    {
        String World { get; }
    }
    public class Parent : IParent
    {
        public String World { get; private set; }
        public Parent(String thing) { World = "Hello " + thing; }
    }
    public class Children : Parent
    {
        public Children() : base("World") { }
    }
