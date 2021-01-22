    public static class Parallel
    {
        public static void ForEach<T>(IEnumerable<T>[] sources,
                                      Action<T> action)
        {
            foreach (var enumerable in sources)
            {
                ThreadPool.QueueUserWorkItem(source => {
                    foreach (var item in (IEnumerable<T>)source)
                        action(item);
                }, enumerable);
            }
        }
    }
    // sample usage:
    static void Main()
    {
        string[] s1 = { "1", "2", "3" };
        string[] s2 = { "4", "5", "6" };
        IEnumerable<string>[] sources = { s1, s2 };
        Parallel.ForEach(sources, s => Console.WriteLine(s));
        Thread.Sleep(0); // allow background threads to work
    }
