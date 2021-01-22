    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            BindingList<Foo> foos = new BindingList<Foo>();
            foos.Add(new Foo("abc"));
            foos.Add(new Foo("def"));
                
            ListBox lb1 = new ListBox(), lb2 = new ListBox();
            lb1.DataSource = lb2.DataSource = foos;
            lb1.DisplayMember = lb2.DisplayMember = "Bar";
            lb1.Dock = DockStyle.Left;
            lb2.Dock = DockStyle.Right;
            
            Button b = new Button();
            b.Text = "Add";
            b.Dock = DockStyle.Top;
            b.Click += delegate
            {
                foos.Add(new Foo("new item"));
            };
            Form form = new Form();
            form.Controls.Add(lb1);
            form.Controls.Add(lb2);
            form.Controls.Add(b);
            Application.Run(form);
        }
    
        
    }
    class Foo
    {
        public Foo(string bar) {this.Bar = bar;}
        private string bar;
        public string Bar {
            get {return bar;}
            set {bar = value;}
        }
    }
