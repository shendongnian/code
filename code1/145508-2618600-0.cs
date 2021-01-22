    public static class Test
    {
        public static void DoSomething<T>(this IEnumerable<T> source)
        {
            Console.WriteLine("general");
        }
        public static void DoSomething<T>(this IEnumerable<T> source) where T :IMyInterface
        {
            Console.WriteLine("specific");
        }
    }
