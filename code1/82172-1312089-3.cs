    using System;
    using System.Collections.Generic;
    namespace test {
        public class Formatter {
            delegate string FormatFunction(object o);
            private string FormatDouble(object o) {
                double d = (double)o;
                return d.ToString("0.0");
            }
            private string FormatDateTime(object o) {
                DateTime d = (DateTime)o;
                return d.ToString("MMM dd yyyy");
            }
            // map types to format function
            private Dictionary<Type, FormatFunction> _formatters = new Dictionary<Type, FormatFunction>();
            public Formatter() {
                _formatters.Add(typeof(double), FormatDouble);
                _formatters.Add(typeof(DateTime), FormatDateTime);
            }
            public string Format(object o) { 
                Type t = o.GetType();
                if (_formatters.ContainsKey(t)){
                    return _formatters[t](o);
                } else {
                    return o.ToString();
                }
            }
        }
        class Program {
            public static void Main() {
                Formatter f = new Formatter();
                Console.WriteLine(f.Format(2.0d));
                Console.WriteLine(f.Format(DateTime.Now));
                Console.WriteLine(f.Format(4));
            }
        }
    }
