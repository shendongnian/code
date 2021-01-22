    class Program
    {
        static void Main(string[] args)
        {
            DynamicFunc f = par =>
                            {
                                foreach (var p in par)
                                    Console.WriteLine(p);
                                return null;
                            };
            f(1, 4, "Hi");
        }
    }
