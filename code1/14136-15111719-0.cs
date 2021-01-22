    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    
    public static class Test
    {
        private static IEnumerable<string> GraphemeClusters(this string s) {
            var enumerator = StringInfo.GetTextElementEnumerator(s);
            while(enumerator.MoveNext()) {
                yield return (string)enumerator.Current;
            }
        }
        private static string ReverseGraphemeClusters(this string s) {
            return string.Join("", s.GraphemeClusters().Reverse().ToArray());
        }
        
        public static void Main()
        {
            var s = "Les Mise\u0301rables";
            var r = s.ReverseGraphemeClusters();
            Console.WriteLine(r);
        }
    }
