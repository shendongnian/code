    using System;
    using System.ComponentModel;
    using System.Drawing.Design;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    class Foo
    {
        [Editor(typeof(FileNameEditor), typeof(UITypeEditor))]
        public string Name { get; set; }
    
        [STAThread]
        static void Main()
        {
            using (Form form = new Form())
            using (PropertyGrid grid = new PropertyGrid())
            {
                grid.Dock = DockStyle.Fill;
                form.Controls.Add(grid);
                grid.SelectedObject = new Foo();
                Application.Run(form);
            }
        }
    }
