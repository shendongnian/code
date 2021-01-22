    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace FormatPlaceholders {
    
        class Program {
    
            class FormatSnooper : IFormatProvider, ICustomFormatter {
    
                public object GetFormat(Type formatType) {
                    return this;
                }
    
                public string Format(string format, object arg, IFormatProvider formatProvider) {
                    Placeholders.Add(((int)arg, format));
                    return null;
                }
    
                internal readonly List<(int index, string format)> Placeholders = new List<(int index, string format)>();
    
            }
    
            public static IEnumerable<(int index, string format)> GetFormatPlaceholders(string format, int max_count = 100) {
    
                var snooper = new FormatSnooper();
    
                string.Format(
                    snooper,
                    format,
                    Enumerable.Range(0, max_count).Cast<object>().ToArray()
                );
    
                return snooper.Placeholders;
    
            }
    
            static void Main(string[] args) {
                foreach (var (index, format) in GetFormatPlaceholders("{1:foo}{4:bar}{1:baz}"))
                    Console.WriteLine($"{index}: {format}");
            }
    
        }
    
    }
