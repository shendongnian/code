    class Program
    {
        public static void Main(string args[])
        {
            MyClass instance = new MyClass();
            instance.Value = "something";
        }
    }
    public class MyClass
    {
        // The following code declares Public Properties 
        // rather than private variables.
        public string Value { get; set; }
        public string Name { get; set; }
    }
