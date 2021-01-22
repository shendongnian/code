    using System;
    using System.Collections.Generic;
    class StringInterner {
        private readonly Dictionary<string, string> lookup
            = new Dictionary<string, string>();
        public string this[string value] {
            get {
                if(value == null) return null;
                if(value == "") return string.Empty;
                string result;
                lock (lookup) { // remove if not needed to be thread-safe     
                    if (!lookup.TryGetValue(value, out result)) {
                        lookup.Add(value, value);
                        result = value;
                    }
                }
                return result;
            }
        }
        public void Clear() {
            lock (lookup) { lookup.Clear(); }
        }
    }
    static class Program {
        static void Main() {
            // this line is to defeat the inbuilt compiler interner
            char[] test = { 'h', 'e', 'l', 'l', 'o', ' ', 'w', 'o', 'r', 'l', 'd' };
    
            string a = new string(test), b = new string(test);
            Console.WriteLine(ReferenceEquals(a, b)); // false
            StringInterner cache = new StringInterner();
            string c = cache[a], d = cache[b];
            Console.WriteLine(ReferenceEquals(c, d)); // true
        }
    }
