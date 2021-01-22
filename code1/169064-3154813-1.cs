    class Program
    {
        public static void Main(string args[])
        {
            MyClass instance = new MyClass();
            instance.Child.ChildValue = "something";
        }
    }
    public class MyClass
    {
        // The following code declares Public Properties 
        // rather than private variables.
        public string Value { get; set; }
        public string Name { get; set; }
        public MyChild Child { get; set; }
        public MyClass()
        {
            this.Child = new MyChild();
        }
    }
    public class MyChild
    {
        public string ChildValue { get; set; }
    }
