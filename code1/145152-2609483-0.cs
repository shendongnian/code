    public partial class Form1 : Form
    {
        int x1, y1, x2, y2;
        bool drag = false;
        Bitmap bm = new Bitmap(1000, 1000);
        Graphics bmg;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bmg = Graphics.FromImage(bm);
        }
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            x1 = e.X;
            y1 = e.Y;
        }
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
            bmg.DrawLine(Pens.Black, x1, y1, e.X, e.Y);
            pictureBox.Invalidate();
        }
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                x2 = e.X;
                y2 = e.Y;
                pictureBox.Invalidate();
            }
        }
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (drag) {
                e.Graphics.DrawImage(bm, 0, 0);
                e.Graphics.DrawLine(Pens.Black, x1, y1, x2, y2);            
            }
            else {
                e.Graphics.DrawImage(bm, 0, 0);
            }
        }
    }
