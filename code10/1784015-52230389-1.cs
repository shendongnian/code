    public partial class Form1 : Form
    {
        Bitmap bitmap;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.ClientSize.Width, 
            pictureBox1.ClientSize.Height, 
            System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }
        Point p1 = new Point();
        Point p2 = new Point();
        Pen pen = new Pen(Color.Magenta, 10);
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                p1 = e.Location;
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                p2 = e.Location;
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawLine(pen, p1, p2);
                pictureBox1.Invalidate();
                g.Dispose();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Aqua;
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
        }
    }
