    class Test
    {
        public int Method(String s, String s2)
        {
            return 99;
        }
    }
    class Program
    {
        static bool UncachedMethod(int x) { return x > 0; }
        static void Main(string[] args)
        {
            var cached = Memoized.Of<int,bool>(UncachedMethod);
            var exampleCall = cached(44);
            var exampleCall2 = cached(44);
            // Capture a non-static member function
            var x = new Test();
            var cachedX = Memoized.Of<String, String,int>(x.Method);
            var exampleCall3 = cachedX("a","b");
        }
    }
