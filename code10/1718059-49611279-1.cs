    class MyClass : ITestVal
    {
        static void Main(string[] args)
        {
            var instance = new MyClass();
            instance.Run();
        }
        public void Run()
        {
            ValidateRe("test");
        }
        public ITestValRes ValidateRe(string input)
        {
            return null; // return an instance of a class implementing ITestValRes here.
        }
    }
