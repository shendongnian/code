    using System;
    using System.Collections.Generic;
    namespace ConsoleApp1 {
    class Program {
        private static Dictionary<int, (bool, DateTime)> _dictionary;
        public static void SomeMethod(int number) {
            if (_dictionary.TryGetValue(number, out (bool isTrue, DateTime timestamp) booltime)) {
                Console.WriteLine($"Found it: {booltime.isTrue}, {booltime.timestamp}");
                }
            else {
                Console.WriteLine($"{number} Not Found");
                }
            }
        static void Main(string[] args) {
            _dictionary = new Dictionary<int, (bool, DateTime)>();
            _dictionary.Add(0, (true, DateTime.Now));
            SomeMethod(1);
            SomeMethod(0);
            }
        }
    }
