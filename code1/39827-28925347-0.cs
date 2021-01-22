    public class MyClass
    {
        // Public parameterless contructor for serialization
        public MyClass() { }
        // Whatever we want in here...
        ...
    }
    // Use this class when we need to pass a JSON object into a web method
    public class MyClassForParams : MyClass
    {
        public MyClassForParams() : base() { }
    }
