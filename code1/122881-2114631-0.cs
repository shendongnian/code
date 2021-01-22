    class Program
    {
        const int COUNT = 10000000;
        static IEnumerable<string> m_value = null;
        static void ParamsMethod(params string[] args)
        { m_value = args; } // do something with it to stop the compiler just optimizing this method away
        static void ListMethod(List<string> args)
        { m_value = args; } // do SOMETHING with it to stop the compiler just optimizing this method away
        static void Main(string[] args)
        {
            var s = new Stopwatch();
            s.Start();
            for (int i = 0; i < COUNT; ++i)
                ParamsMethod("a", "b", "c");
            Console.WriteLine("params took {0} ms", s.ElapsedMilliseconds);
            s.Reset();
            s.Start();
            for (int i = 0; i < COUNT; ++i)
                ListMethod(new List<string> { "a", "b", "c" });
            Console.WriteLine("list took {0} ms", s.ElapsedMilliseconds);
        }
    }
