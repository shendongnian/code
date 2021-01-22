    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    static class Program {
        static void Main() { // just some test data...
            var data = new[] { new { Foo = "abc", Bar = 123 }, new { Foo = "def", Bar = 456 } };
            Write(data, Console.Out, true, "|");
        }
        public static void Write<T>(IEnumerable<T> items, TextWriter output, bool writeHeaders, string delimiter) {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            foreach (T item in items) {
                bool firstCol = true;
                if (writeHeaders) {                
                    foreach (PropertyDescriptor prop in properties) {
                        if (firstCol) {
                            firstCol = false;
                        } else {
                            output.Write(delimiter);
                        }
                        output.Write(prop.Name);                    
                    }
                    output.WriteLine();
                    writeHeaders = false;
                    firstCol = true;
                }
                foreach (PropertyDescriptor prop in properties) {
                    if (firstCol) {
                        firstCol = false;
                    } else {
                        output.Write(delimiter);
                    }
                    output.Write(prop.Converter.ConvertToString(prop.GetValue(item)));
                }
                output.WriteLine();
            }
        }
    }
