    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    class Person
    {
        public string Name { get; set; }
        [DisplayName("Eye Color")]
        public string EyeColor { get; set; }
    }
    static class Program
    {   
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            using (var form = new Form())
            using (var grid = new DataGridView { Dock = DockStyle.Fill})
            using (var btn1 = new Button { Dock = DockStyle.Bottom, Text = "Button 1"})
            using (var btn2 = new Button { Dock = DockStyle.Bottom, Text = "Button 2" })
            {
    
                btn1.Click += delegate
                {
                    form.Text = "Button 1 clicked";
                    if (grid.CurrentRow != null)
                    {
                        form.Text += ": " + ((Person)grid.CurrentRow.DataBoundItem).Name;
                    }
                };
                btn2.Click += delegate
                {
                    form.Text = "Button 2 clicked";
                    if (grid.CurrentRow != null)
                    {
                        form.Text += ": " + ((Person)grid.CurrentRow.DataBoundItem).Name;
                    }
                };
                form.Controls.Add(btn1);
                form.Controls.Add(btn2);
                form.Controls.Add(grid);
                var data = new BindingList<Person>
                {
                    new Person { Name = "Fred", EyeColor = "green"},
                    new Person { Name = "Barney", EyeColor = "brown"},
                    new Person { Name = "Wilma", EyeColor = "blue"},
                    new Person { Name = "Betty", EyeColor = "blue"},
                };
                grid.DataSource = data;
                Application.Run(form);
            }
        }
    }
