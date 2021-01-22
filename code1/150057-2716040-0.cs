        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint);
            }
            Bitmap m_cache;
            void pictureBox1_Paint(object sender, PaintEventArgs e)
            {
                if (m_cache == null)
                {
                    m_cache = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    var g = Graphics.FromImage(m_cache);
                    g.FillRectangle(new SolidBrush(Color.White), 
                                    0, 0, m_cache.Width, m_cache.Height);
                    g.DrawString("Hello World", this.Font, 
                                 new SolidBrush(Color.Black), 0, 0);
                }
                e.Graphics.DrawImage(m_cache, 0, 0);
            }
            private void button1_Click(object sender, EventArgs e)
            {
                m_cache.Save("\\myimage.jpg", ImageFormat.Jpeg);
            }
        }
