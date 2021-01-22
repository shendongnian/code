    class Program
    {
        static void Main(string[] args)
        {
            var x = new MyClass<string>() { Value = "34" };
            var y = new MyClass<int>() { Value = 3 };
            var list = new List<IMyClass>();
            list.Add(x);
            list.Add(y);
            foreach (var item in list)
            {
                Console.WriteLine(item.GetValue);
            }
        }
        private interface IMyClass
        {
            object GetValue { get; }
        }
        private class MyClass<T> : IMyClass
        {
            public T Value;
            public object GetValue
            {
                get
                {
                   return Value;
                }
            }
        }
    }
