    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ListPartitionTest
    {
        public static class IEnumerableExtensions
        {
            public static KeyValuePair<IEnumerable<T>, IEnumerable<T>> Partition<T>(this IEnumerable<T> items, Func<T, bool> f)
            {
                return items.Aggregate(
                    new KeyValuePair<IEnumerable<T>, IEnumerable<T>>(Enumerable.Empty<T>(), Enumerable.Empty<T>()),
                    (acc, i) =>
                    {
                        if (f(i))
                        {
                            return new KeyValuePair<IEnumerable<T>, IEnumerable<T>>(acc.Key.Concat(new[] { i }), acc.Value);
                        }
                        else
                        {
                            return new KeyValuePair<IEnumerable<T>, IEnumerable<T>>(acc.Key, acc.Value.Concat(new[] { i }));
                        }
                    });
            }
        }
    
        class PrimeNumbers
        {
            public int Floor { get; private set; }
            public int Ceiling { get; private set; }
    
            private IEnumerable<int> _sieve;
    
            public PrimeNumbers(int floor, int ceiling)
            {
                Floor = floor;
                Ceiling = ceiling;
            }
    
            public List<int> Go()
            {
                _sieve = Enumerable.Range(Floor, (Ceiling - Floor) + 1).ToList();
    
                for (int i = (Floor < 2) ? 2 : Floor; i <= Math.Sqrt(Ceiling); i++)
                {
                    _sieve = _sieve.Where(x => (x % i != 0 && x != i));
    
                    foreach (int x in _sieve)
                    {
                        Console.Write("{0}, ", x);
                    }
                    Console.WriteLine();
                }
    
                return _sieve.ToList();
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();
                int floor = 1;
                int ceiling = 10;
    
                s.Start();
                PrimeNumbers p = new PrimeNumbers(floor, ceiling);
                p.Go();
                //foreach (int i in p.Go()) Console.Write("{0} ", i);
                s.Stop();
    
                Console.WriteLine("\n{0} to {1} completed in {2}", floor, ceiling, s.Elapsed.TotalMilliseconds);
    
                Console.ReadLine();
            }
        }
    }
