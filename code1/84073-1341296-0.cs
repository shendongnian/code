    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        class SuperTextBox : TextBox
        {
            protected override void OnLocationChanged(EventArgs e)
            {
                base.OnLocationChanged(e);
                
                EventHandler handler = (EventHandler)Events[LeftChangedKey];
                if (handler != null) handler(this, EventArgs.Empty);
            }
            public event EventHandler LeftChanged
            {
                add { Events.AddHandler(LeftChangedKey, value); }
                remove { Events.RemoveHandler(LeftChangedKey, value); }
            }
            public new int Left
            {
                get { return base.Left; }
                set { base.Left = value; }
            }
            private static readonly object LeftChangedKey = new object();
        }
        class Person {
            private int value;
            public int Value {
                get {return value;}
                set {
                    this.value = value;
                    EventHandler handler = ValueChanged;
                    if(handler!=null)
                    {
                        handler(this, EventArgs.Empty);
                    }
                }
            }
            public event EventHandler ValueChanged;
        }
        static class Program
        {
            static void Main()
            {
                Button btn;
                TextBox txt;
                Person p = new Person { Value = 10 };
                using (Form form = new Form {
                    DataBindings = {{ "Text", p, "Value"}},
                    Controls = {
                        (txt = new SuperTextBox {
                            DataBindings = {{ "Left", p, "Value", false,
                                DataSourceUpdateMode.OnPropertyChanged}}
                        }),
                        (btn = new Button {
                            Text = "bump",
                            Dock = DockStyle.Bottom
                        })
                    }
                }) {
                    btn.Click += delegate { txt.Left += 5; };
                    Application.Run(form);
                }
            }
        }
    }
