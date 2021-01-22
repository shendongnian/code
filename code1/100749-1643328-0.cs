    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    class MyDisplayNameAttribute : DisplayNameAttribute {
        public MyDisplayNameAttribute(string value) : base(value) {}
        public override string DisplayName {
            get {
                return @"/// " + base.DisplayNameValue + @" \\\";
            }
        }
    }
    class Foo {
        [MyDisplayName("blip")]
        public string Bar { get; set; }
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            using (Form form = new Form {
                Controls = {
                    new PropertyGrid {
                        Dock = DockStyle.Fill,
                        SelectedObject = new Foo { Bar = "abc"}}
                }
            }) {
                Application.Run(form);
            }
        }
    }
