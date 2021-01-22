    public partial class Form1 : Form
        {
        int xFirst, yFirst;
        Bitmap bm = new Bitmap(1000, 1000);
        Graphics bmG;
        Pen pen = new Pen(Color.Black, 1);
        bool draw = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bmG = Graphics.FromImage(bm);
            bmG.Clear(Color.White);
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            xFirst = e.X;
            yFirst = e.Y;
            draw = true;
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            bmG.DrawLine(pen, xFirst, yFirst, e.X, e.Y);
            draw = false;
            Invalidate();
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (draw)
            {
                Invalidate();
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (draw) {
                e.Graphics.DrawImage(bm, 0, 0);
                e.Graphics.DrawLine(pen, xFirst, yFirst, e.X, e.Y);
            } else {
                e.Graphics.DrawImage(bm, 0, 0);
            }
        }
    }
