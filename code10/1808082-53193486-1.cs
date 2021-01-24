    public interface IParent
    {
        String Message { get; protected set; }
    }
    public class Parent : IParent
    {
        public Parent(Byval thing as string) { Message = "Hello " + thing; }
    }
    public class Children : Parent
    {
        public Children() { base("World"); }
    }
