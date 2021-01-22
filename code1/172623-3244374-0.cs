    using System;
    static class Program {
        static bool In(this object obj, params object[] values) {
            foreach (object value in values) {
                if (obj.Equals(value)) {
                    return true;
                }
            }
            return false;
        }
        static void Main(string[] args) {
            bool test1 = 3.In(1, 2, 3);
            bool test2 = 5.In(1, 2, 3);
        }
    }
