    using System;
    using System.Collections.Generic;
    
    class BiDictionary<TFirst, TSecond>
    {
        IDictionary<TFirst, TSecond> firstToSecond = new Dictionary<TFirst, TSecond>();
        IDictionary<TSecond, TFirst> secondToFirst = new Dictionary<TSecond, TFirst>();
        
        public void Add(TFirst first, TSecond second)
        {
            if (firstToSecond.ContainsKey(first) ||
                secondToFirst.ContainsKey(second))
            {
                throw new ArgumentException("Duplicate first or second");
            }
            firstToSecond.Add(first, second);
            secondToFirst.Add(second, first);
        }
        
        public bool TryGetByFirst(TFirst first, out TSecond second)
        {
            return firstToSecond.TryGetValue(first, out second);
        }
    
        public bool TryGetBySecond(TSecond second, out TFirst first)
        {
            return secondToFirst.TryGetValue(second, out first);
        }
    }
    
    class Test
    {
        static void Main()
        {
            BiDictionary<int, string> greek = new BiDictionary<int, string>();
            greek.Add(1, "Alpha");
            greek.Add(2, "Beta");
            int x;
            greek.TryGetBySecond("Beta", out x);
            Console.WriteLine(x);
        }
    }
