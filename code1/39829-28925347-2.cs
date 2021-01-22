    public class MyClass
    {
        protected internal MyClass() { }
        public MyClass(Object someParameter) { }
        ...
    }
    // Use this class when we need to pass a JSON object into a web method
    public class MyClassForParams : MyClass
    {
        public MyClassForParams() : base() { }
    }
