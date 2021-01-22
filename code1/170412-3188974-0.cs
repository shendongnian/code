    using System;
    
    namespace Elegant {
        public class Range {
            public int Lower { get; set; }
            public int Upper { get; set; }
        }
    
        public static class Ext {
            public static Range To(this int lower, int upper) {
                return new Range { Lower = lower, Upper = upper };
            }
    
            public static bool In(this int n, Range r) {
                return n >= r.Lower && n <= r.Upper;
            }
        }
    
        class Program {
            static void Main() {
                int x = 55;
                if (x.In(1.To(100)))
                    Console.WriteLine("it's in range! elegantly!");
            }
        }
    }
