    class Program
    {
        class ScopedReset<T> : IDisposable
        {
            T originalValue = default(T);
            Action<T> _setter;
            public ScopedReset(Func<T> getter, Action<T> setter, T v)
            {
                originalValue = getter();
                setter(v);
                _setter = setter;
            }
            public void Dispose()
            {
                _setter(originalValue);
            }
        }
        static int counter = 0;
        static void Main(string[] args)
        {
            counter++;
            counter++;
            Console.WriteLine(counter); 
            using (new ScopedReset<int>(() => counter, i => counter = i, 1))            
                Console.WriteLine(counter);
            
            Console.WriteLine(counter);
        }
    }
