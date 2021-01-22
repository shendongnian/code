    using System;
    using System.Drawing;
    using System.Windows.Forms;
    class Foo {
        private Bitmap bmp;
        public Bitmap Bar {
            get { return bmp; }
            set { bmp = value; }
        }
        private void ResetBar() { bmp = null; }
        private bool ShouldSerializeBar() { return bmp != null; }
    }
    static class Program {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Form form = new Form();
            PropertyGrid grid = new PropertyGrid();
            grid.Dock = DockStyle.Fill;
            grid.SelectedObject = new Foo();
            form.Controls.Add(form);
            Application.Run(form);
        }
    }
