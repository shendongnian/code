    public class Foo
    {
        public int Fibonacci(int n)
        {
            return n > 1 ? Fibonacci(n - 1) + Fibonacci(n - 2) : n;
        }
    }
    class Program
    {
        public static Func<Т, TResult> Memoize<Т, TResult>(Func<Т, TResult> f) where Т : IEquatable<Т>
        {
            Dictionary<Т, TResult> map = new Dictionary<Т, TResult>();
            return a =>
            {
                TResult local;
                if (!TryGetValue<Т, TResult>(map, a, out local))
                {
                    local = f(a);
                    map.Add(a, local);
                }
                return local;
            };
        }
        private static bool TryGetValue<Т, TResult>(Dictionary<Т, TResult> map, Т key, out TResult value) where Т : IEquatable<Т>
        {
            EqualityComparer<Т> comparer = EqualityComparer<Т>.Default;
            foreach (KeyValuePair<Т, TResult> pair in map)
            {
                if (comparer.Equals(pair.Key, key))
                {
                    value = pair.Value;
                    return true;
                }
            }
            value = default(TResult);
            return false;
        }
        static void Main(string[] args)
        {
            var foo = new Foo();
            // Transform the original function and render it with memory
            var memoizedFibonacci = Memoize<int, int>(foo.Fibonacci);
            // memoizedFibonacci is a transformation of the original function that can be used from now on:
            // Note that only the first call will hit the original function
            Console.WriteLine(memoizedFibonacci(3));
            Console.WriteLine(memoizedFibonacci(3));
            Console.WriteLine(memoizedFibonacci(3));
            Console.WriteLine(memoizedFibonacci(3));
        }
    }
