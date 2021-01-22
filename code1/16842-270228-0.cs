    class MyAttribute: Attribute
    {
        public MyAttribute(params object[] args)
        {
        }
    }
    [MyAttribute("hello", 2, 3.14f)]
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
