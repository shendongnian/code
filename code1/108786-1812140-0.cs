    using System;
    using System.Collections.Generic;
    static class Program {
        static void Main() {
            ApplicationType value = ApplicationType.B;
            Console.WriteLine("A: " + GetSelected(value, ApplicationType.A));
            Console.WriteLine("B: " + GetSelected(value, ApplicationType.B));
            Console.WriteLine("C: " + GetSelected(value, ApplicationType.C));
        }
        private static string GetSelected<T>(T x, T y) {
            return EqualityComparer<T>.Default.Equals(x, y) ? " selected " : "";
        }
        enum ApplicationType { A, B, C }
    }
