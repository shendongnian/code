    static class Program
    {
        static void Main()
        {
            object obj = 123.45;
            typeof(Program).GetMethod("DoSomething")
                .MakeGenericMethod(obj.GetType())
                .Invoke(null, new object[] { obj });
        }
        public static void DoSomething<T>(T value)
        {
            T item = value; // well... now what?
        }    
    }
