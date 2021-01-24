    class Example
    {
        public static void StaticMethod() { }
        public void InstanceMethod() { }
        public Action Property { get; } = () => { };
    }
    static class Program
    {
        static void Main()
        {
            Example.StaticMethod();
            var ex = new Example();
            ex.InstanceMethod();
            ex.Property();
        }
    }
