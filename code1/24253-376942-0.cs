    class FooAttribute : Attribute
    {
        public string Bar { get; set; }
    }
    static class Program
    {
        [Foo(Bar="abc")]
        public static void Main()
        {
            MethodInfo method = typeof(Program).GetMethod("Main");
            var attrib = (FooAttribute) Attribute.GetCustomAttribute(method, typeof(FooAttribute));
            Console.WriteLine("Original: " + attrib.Bar);
            attrib.Bar = "def";
            Console.WriteLine("Updated: " + attrib.Bar);
            attrib = (FooAttribute)Attribute.GetCustomAttribute(method, typeof(FooAttribute));
            Console.WriteLine("Look again: " + attrib.Bar);
        }
    }
