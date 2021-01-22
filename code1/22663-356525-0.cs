    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    
    class Foo {
        [MyDisplayName("bar")] // perhaps use a constant: SomeType.SomeResName
        public string Bar {get; set; }
    }
    
    public class MyDisplayNameAttribute : DisplayNameAttribute {
        public MyDisplayNameAttribute(string key) : base(Lookup(key)) {}
    
        static string Lookup(string key) {
            try {
                // get from your resx or whatever
                return "le bar";
            } catch {
                return key; // fallback
            }
        }
    }
    
    class Program {
        [STAThread]
        static void Main() {
            Application.Run(new Form { Controls = {
                new PropertyGrid { SelectedObject =
                    new Foo { Bar = "abc" } } } });
        }
    }
