    using System;
    using System.Collections.Generic;
    
    class CustomStringComparer : IEqualityComparer<string> {
        public bool Equals(string x, string y) {
            return string.Equals(x, y);
        }
        public int GetHashCode(string s) {
            return string.IsNullOrEmpty(s) ? 0 :
                s.Length + 273133 * (int)s[0];
        }
        private CustomStringComparer() { }
        public static readonly CustomStringComparer Default
            = new CustomStringComparer();
    }
    static class Program {
        static void Main() {
            HashSet<string> set = new HashSet<string>(
                new string[] { "abc", "def", "ghi" }, CustomStringComparer.Default);
            Console.WriteLine(set.Contains("abc"));
            Console.WriteLine(set.Contains("abcde"));
        }
    }
