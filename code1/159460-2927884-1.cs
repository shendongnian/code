    class Program
    {
        delegate double CommonDelegate(string location1, string location2, int nGrams);
        static void Main(string[] args)
        {
            var functions = new CommonDelegate[]
            {
                AllSubstrings,
                FullFingerPrinting
            };
            foreach (var function in functions)
            {
                Console.WriteLine("{0} returned {1}",
                    function.Method.Name,
                    function("foo", "bar", 42)
                );
            }
        }
        static double AllSubstrings(string location1, string location2, int nGrams)
        {
            // ...
            return 1.0;
        }
        static double FullFingerPrinting(string location1, string location2, int nGrams)
        {
            // ...
            return 2.0;
        }
    }
