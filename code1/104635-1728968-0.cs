    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    class MyControl : UserControl
    {
        private Button button;
        private Label label;
        public MyControl()
        {
            button = new Button { Dock = DockStyle.Right, Text = "Click me" };
            label = new Label { Dock = DockStyle.Left};
            Controls.Add(button);
            Controls.Add(label);
        }
        [Category("Wonder Control")]
        public string CaptionText { get { return label.Text; } set { label.Text = value; } }
        [Category("Wonder Control")]
        public Color ButtonBackColor { get { return button.BackColor; } set { button.BackColor = value; } }
    }
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (Form form = new Form())
            using (MyControl ctrl = new MyControl())
            using (PropertyGrid grid = new PropertyGrid())
            {
                ctrl.ButtonBackColor = Color.Red;
                ctrl.CaptionText = "Caption";
                ctrl.Dock = DockStyle.Fill;
                grid.Dock = DockStyle.Right;
                form.Controls.Add(ctrl);
                form.Controls.Add(grid);
                grid.SelectedObject = ctrl;
                Application.Run(form);
            }
            
        }
    }
