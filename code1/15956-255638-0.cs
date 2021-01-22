    using System;
    using System.Collections.Generic;
    using System.Text;
    
    class BiDictionary<TFirst, TSecond>
    {
        IDictionary<TFirst, IList<TSecond>> firstToSecond = new Dictionary<TFirst, IList<TSecond>>();
        IDictionary<TSecond, IList<TFirst>> secondToFirst = new Dictionary<TSecond, IList<TFirst>>();
        
        private static IList<TFirst> EmptyFirstList = new TFirst[0];
        private static IList<TSecond> EmptySecondList = new TSecond[0];
        
        public void Add(TFirst first, TSecond second)
        {
            IList<TFirst> firsts;
            IList<TSecond> seconds;
            if (!firstToSecond.TryGetValue(first, out seconds))
            {
                seconds = new List<TSecond>();
                firstToSecond[first] = seconds;
            }
            if (!secondToFirst.TryGetValue(second, out firsts))
            {
                firsts = new List<TFirst>();
                secondToFirst[second] = firsts;
            }
            seconds.Add(second);
            firsts.Add(first);
        }
        
        // Note potential ambiguity using indexers (e.g. mapping from int to int)
        // Hence the methods as well...
        public IList<TSecond> this[TFirst first]
        {
            get { return GetByFirst(first); }
        }
    
        public IList<TFirst> this[TSecond second]
        {
            get { return GetBySecond(second); }
        }
        
        public IList<TSecond> GetByFirst(TFirst first)
        {
            IList<TSecond> list;
            if (!firstToSecond.TryGetValue(first, out list))
            {
                return EmptySecondList;
            }
            return new List<TSecond>(list); // Create a copy for sanity
        }
    
        public IList<TFirst> GetBySecond(TSecond second)
        {
            IList<TFirst> list;
            if (!secondToFirst.TryGetValue(second, out list))
            {
                return EmptyFirstList;
            }
            return new List<TFirst>(list); // Create a copy for sanity
        }
    }
    
    class Test
    {
        static void Main()
        {
            BiDictionary<int, string> greek = new BiDictionary<int, string>();
            greek.Add(1, "Alpha");
            greek.Add(2, "Beta");
            greek.Add(5, "Beta");
            ShowEntries(greek, "Alpha");
            ShowEntries(greek, "Beta");
            ShowEntries(greek, "Gamma");
        }
        
        static void ShowEntries(BiDictionary<int, string> dict, string key)
        {
            IList<int> values = dict[key];
            StringBuilder builder = new StringBuilder();
            foreach (int value in values)
            {
                if (builder.Length != 0)
                {
                    builder.Append(", ");
                }
                builder.Append(value);
            }
            Console.WriteLine("{0}: [{1}]", key, builder);
        }
    }
