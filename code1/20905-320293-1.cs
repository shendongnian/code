    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    
    class MyForm : Form
    {
        public MyForm()
        {
            MyBusinessObject obj = new MyBusinessObject();
            Button btn = new Button();
            btn.Click += delegate { Foo++; };
            DataBindings.Add("Foo", obj, "Bar", false, DataSourceUpdateMode.OnPropertyChanged);
            DataBindings.Add("Text", obj, "Bar");
            Controls.Add(btn);
        }
    
        private int foo;
        public event EventHandler FooChanged;
        public int Foo
        {
            get { return foo; }
            set
            {
                if (foo != value)
                {
                    foo = value;
                    Debug.WriteLine("Foo changed to " + foo);
                    if (FooChanged != null) FooChanged(this, EventArgs.Empty);
                }
            }
        }
    }
    
    class MyBusinessObject
    {
        private int bar;
        public event EventHandler BarChanged;
        public int Bar
        {
            get { return bar; }
            set
            {
                if (bar != value)
                {
                    bar = value;
                    Debug.WriteLine("Bar changed to " + bar);
                    if (BarChanged != null) BarChanged(this, EventArgs.Empty);
                }
            }
        }
    }
    
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.Run(new MyForm());
        }
    }
