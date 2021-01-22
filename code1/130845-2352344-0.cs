    public static class MyClass
    {
        public static void Print(Func<int, int> converter)
        {
            Console.WriteLine("1: {0}", converter(1));
        }
    }
