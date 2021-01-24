    static void Main()
    {
        new TestClass();
        Console.WriteLine("Not deadlocked");
    }
    public class TestClass
    {
        static Type uLongType = typeof(ulong);
        static TestClass Instance = new TestClass();
            
        static TestClass() { }
        public TestClass()
        {
            var values = Enumerable.Range(0, 20).ToList();
            Parallel.ForEach(values, (value) =>
            {
                uLongType.ToString();
                //Forcing the lambda to be compiled as an instance method
                //changes the behavior but deadlocks can happen either way
                InstanceMethod();
            });
        }
        void InstanceMethod() { }
    }
