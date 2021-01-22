    class Program
    {
        static void Main(string[] args)
        {
            var x = new MyClass<string>();
            var y = new MyClass<int>();
            var list = new List<IMyClass>();
            list.Add(x);
            list.Add(y);
        }
        private interface IMyClass
        {
        }
        private class MyClass<T> : IMyClass
        {
        }
    }
