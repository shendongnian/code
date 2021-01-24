    public partial class Form1 : Form
    {
        Point mouse;
        MouseButtons buttons;
        public Form1()
        {
            InitializeComponent();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (sender is Panel panel)
            {
                var g = e.Graphics;
                var pt = mouse;
                using (Pen pen = new Pen(Color.Red))
                {
                    g.DrawLine(pen, pt.X, 0, pt.X, panel.Height);
                }
            }
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            mouse=e.Location;
            buttons=e.Button;
            panel1.Refresh();
        }
    }
