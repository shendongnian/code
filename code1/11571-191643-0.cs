    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            BindingList<Foo> foos = new BindingList<Foo> {
                new Foo {Bar="abc" }, new Foo {Bar="def"}
            };
            ListBox lb1 = new ListBox { DataSource = foos, DisplayMember = "Bar", Dock = DockStyle.Left},
                lb2 = new ListBox { DataSource = foos, DisplayMember = "Bar", Dock = DockStyle.Right};
            Button b = new Button { Text = "Add", Dock = DockStyle.Top };
            b.Click += delegate
            {
                foos.Add(new Foo { Bar = "new item" });
            };
            Application.Run(new Form { Controls = { lb1, lb2, b } });
        }
    
        
    }
    class Foo
    {
        public string Bar { get; set; }
    }
