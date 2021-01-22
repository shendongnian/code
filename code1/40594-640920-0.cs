    namespace ListSetTiming
    {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            // foo and bar have some identical elements (given a case-insensitive match)
            List<string> foo = GetFoo();
            List<string> bar = GetBar();
            Stopwatch timer = new Stopwatch();
            
            timer.Start();
            // remove non matches
            var f = foo.Where(x => !bar.Contains(x)).ToList();
            var b = bar.Where(x => !foo.Contains(x)).ToList();
            timer.Stop();
            Debug.WriteLine(String.Format("Original: {0} ms", timer.ElapsedMilliseconds));
            timer.Reset();
            timer.Start();
            HashSet<String> intersect = new HashSet<String>(foo);
            intersect.IntersectWith(bar);
            HashSet<String> fSet = new HashSet<String>(foo);
            HashSet<String> bSet = new HashSet<String>(bar);
            fSet.ExceptWith(intersect);
            bSet.ExceptWith(intersect);
            timer.Stop();
            HashSet<String> fCheck = new HashSet<String>(f);
            HashSet<String> bCheck = new HashSet<String>(b);
            Debug.WriteLine(String.Format("Hashset: {0} ms", timer.ElapsedMilliseconds));
            Console.WriteLine("Sets equal? {0} {1}", fSet.SetEquals(fCheck), bSet.SetEquals(bCheck)); //bSet.SetEquals(set));
            Console.ReadKey();
        }
        static Random _rnd = new Random();
        private static List<String> GetBar()
        {
            return getRandomStrings();
        }
        private static List<String> GetFoo()
        {
            return getRandomStrings();
        }
        private const int Count = 50000;
        private static List<string> getRandomStrings() 
        {
            List<String> strings = new List<String>(Count);
            Char[] chars = new Char[10];
            for (int i = 0; i < Count; i++)
            {
                Int32 len = _rnd.Next(2, 10);
                for (int j = 0; j < len; j++)
                {
                    Char c = (Char)_rnd.Next('a', 'z');
                    chars[j] = c;
                }
                strings.Add(new String(chars, 0, len));
            }
            return strings;
        }
    }
}
