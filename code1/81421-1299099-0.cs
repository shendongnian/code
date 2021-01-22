    using System;
    using System.Collections.Generic;
    namespace test {
        class Program {
            enum X { 
                one,
                two,
                three,
                four
            }
            class XCompare : IComparer<X> {
                public int Compare(X x, X y) {
                    // TBA: your criteria here
                    return x.ToString().Length - y.ToString().Length;
                }
            }
            static void Main(string[] args) {
                List<X> xs = new List<X>((X[])Enum.GetValues(typeof(X)));
                xs.Sort(new XCompare());
                foreach (X x in xs) {
                    Console.WriteLine(x);
                }
            }
        }
    }
