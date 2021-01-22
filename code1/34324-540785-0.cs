    using System;
    using System.ComponentModel;
    class Foo {
        [AttributeProvider(typeof(IListSource))]
        public object Bar { get; set; }
    
        static void Main() {
            var bar = TypeDescriptor.GetProperties(typeof(Foo))["Bar"];
            foreach (Attribute attrib in bar.Attributes) {
                Console.WriteLine(attrib);
            }
        }
    }
