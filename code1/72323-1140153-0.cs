    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Point local = this.PointToClient(Cursor.Position);
            e.Graphics.DrawEllipse(Pens.Red, local.X-25, local.Y-25, 20, 20);
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Invalidate();
        }
    }
