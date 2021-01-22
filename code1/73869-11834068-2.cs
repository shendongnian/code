    [Test]
    class Program
    {
        public static int SomeValue;
        [Test]
        public static void Main(string[] args)
        {
            var method = typeof(Program).GetMethod("Main");
            var type = typeof(Program);
            SomeValue = 1;
            Console.WriteLine(method.GetCustomAttributes(false)
                .OfType<TestAttribute>().First().SomeValue);
            // prints "1"
            SomeValue = 2;
            Console.WriteLine(method.GetCustomAttributes(false)
                .OfType<TestAttribute>().First().SomeValue);
            // prints "2"
            SomeValue = 3;
            Console.WriteLine(type.GetCustomAttributes(false)
                .OfType<TestAttribute>().First().SomeValue);
            // prints "3"
            SomeValue = 4;
            Console.WriteLine(type.GetCustomAttributes(false)
                .OfType<TestAttribute>().First().SomeValue);
            // prints "4"
            Console.ReadLine();
        }
    }
    [AttributeUsage(AttributeTargets.All)]
    class TestAttribute : Attribute
    {
        public int SomeValue { get; private set; }
        public TestAttribute()
        {
            SomeValue = Program.SomeValue;
        }
    }
