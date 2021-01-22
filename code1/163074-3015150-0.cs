    using System;
    using System.Collections.Generic;
    
    class Program {
        static void Main(string[] args) {
            var d = new Dictionary<Key, int>(new MyComparer());
            d.Add(new Key("A"), 1);
            Console.WriteLine(d.ContainsKey(new Key("a")));
            Console.ReadLine();
        }
        private class MyComparer : IEqualityComparer<Key> {
            public bool Equals(Key x, Key y) {
                return string.Compare(x.Name, y.Name, true) == 0;
            }
            public int GetHashCode(Key obj) {
                return obj.Name.ToUpper().GetHashCode();
            }
        }
        public class Key {
            public string Name { get; set; }
            public Key(string name) { Name = name; }
        }
    }
