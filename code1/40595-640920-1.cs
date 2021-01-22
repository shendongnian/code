    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            // foo and bar have some identical elements (given a case-insensitive match)
            var foo = getRandomStrings();
            var bar = getRandomStrings();
            var timer = new Stopwatch();
            
            timer.Start();
            // remove non matches
            var f = foo.Where(x => !bar.Contains(x)).ToList();
            var b = bar.Where(x => !foo.Contains(x)).ToList();
            timer.Stop();
            Debug.WriteLine(String.Format("Original: {0} ms", timer.ElapsedMilliseconds));
            timer.Reset();
            timer.Start();
            var intersect = new HashSet<String>(foo);
            intersect.IntersectWith(bar);
            var fSet = new HashSet<String>(foo);
            var bSet = new HashSet<String>(bar);
            fSet.ExceptWith(intersect);
            bSet.ExceptWith(intersect);
            timer.Stop();
            var fCheck = new HashSet<String>(f);
            var bCheck = new HashSet<String>(b);
            Debug.WriteLine(String.Format("Hashset: {0} ms", timer.ElapsedMilliseconds));
            Console.WriteLine("Sets equal? {0} {1}", fSet.SetEquals(fCheck), bSet.SetEquals(bCheck)); //bSet.SetEquals(set));
            Console.ReadKey();
        }
        static Random _rnd = new Random();
        private const int Count = 50000;
        private static List<string> getRandomStrings() 
        {
            var strings = new List<String>(Count);
            var chars = new Char[10];
            for (var i = 0; i < Count; i++)
            {
                var len = _rnd.Next(2, 10);
                for (var j = 0; j < len; j++)
                {
                    var c = (Char)_rnd.Next('a', 'z');
                    chars[j] = c;
                }
                strings.Add(new String(chars, 0, len));
            }
            return strings;
        }
    }
