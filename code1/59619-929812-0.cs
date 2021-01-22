    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
     
    static class P
    {
        private static List<int> _list = new List<int>();
     
        public static int Nth(int n)
        {
            if (_list.Count == 0 || _list.Count <= n)
            {
                GenerateNextPrimes().First(p => _list.Count >= n);            
            }
     
            return _list[n];
        }
     
        public static int PrimeOrd(int prime)
        {
            var primes = GrowPrimesTo(prime);
            return primes.IndexOf(prime);
        }
     
        public static List<int> Factor(int N)
        {
            List<int> ret = new List<int>();        
            GrowPrimesTo(N);
    
            for (int ixDivisor = 0; ixDivisor < _list.Count; ixDivisor++)
            {
                int currentDivisor = _list[ixDivisor];
    
                while (N % currentDivisor == 0)
                {
                    N /= currentDivisor;
                    ret.Add(currentDivisor);
                }
    
                if (N <= 1)
                {
                    break;
                }
            }
     
            return ret;
        }
    
        private static List<int> GrowPrimesTo(int max)
        {
            if (_list.LastOrDefault() >= max)
            {
                return _list;
            }
    
            GenerateNextPrimes().First(prime => prime >= max);
            return _list;        
        }
     
        private static IEnumerable<int> GenerateNextPrimes()
        {
            if (_list.Count == 0)
            {
                _list.Add(2);
                yield return 2;
            }
            
            Func<int, bool> IsPrime =
                n =>
                {
                    // cache upperBound
                    int upperBound = (int)Math.Sqrt(n);
                    for (int ixPrime = 0; ixPrime < _list.Count; ixPrime++)
                    {
                        int currentDivisor = _list[ixPrime];
                        if (currentDivisor > upperBound)
                        {
                            return true;
                        }
    
                        if ((n % currentDivisor) == 0)
                        {
                            return false;
                        }
                    }
    
                    return true;
                };
    
            // Always start on next odd number
            int startNum = _list.Count == 1 ? 3 : _list[_list.Count - 1] + 2;
            for (int i = startNum; i < Int32.MaxValue; i += 2)
            {
                if (IsPrime(i))
                {
                    _list.Add(i);
                    yield return i;
                }
            }
        }
     
        public static string Convert(int n)
        {
            if (n == 0) return ".";
            if (n == 1) return "()";
     
            StringBuilder sb = new StringBuilder();
            var p = Factor(n);
            var max = PrimeOrd(p.Last());
            for (int i = 0; i <= max; i++)
            {
                var power = p.FindAll(x => x == Nth(i)).Count;
                sb.Append(Convert(power));
            }
            return "(" + sb.ToString() + ")";
        }
    }
     
    class Program
    {
        static void Main(string[] args)
        {        
            string line = Console.ReadLine();
            int num;
    
            if(int.TryParse(line, out num))
            {   
                Console.WriteLine("{0}: '{1}'", num, P.Convert(num));             
            }
            else
            {
                Console.WriteLine("You didn't entered number!");
            }
        }
    }
