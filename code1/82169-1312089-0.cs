    using System;
    namespace test {
        static class Formatter {
            const string DateFormat = "MMM dd yyyy";
            const string NumberFormat = "0.0";
            public static string Format(double d) {
                return d.ToString(NumberFormat);
            }
            public static string Format(DateTime d) {
                return d.ToString(DateFormat);
            }
            // most generic method
            public static string Format(object o) {
                return o.ToString();
            }
        }
        class Program {
            public static void Main() {
                Console.WriteLine(Formatter.Format(2.0d));
                Console.WriteLine(Formatter.Format(DateTime.Now));
                // an integer => no specific function defined => pick the
                // most generic overload (object)
                Console.WriteLine(Formatter.Format(4));
            }
        }
    }
