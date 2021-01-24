       public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }
        Bitmap bm = null;
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            pictureBox1.Image = bm;
        }
        private void btn_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp); *.PNG|*.jpg; *.jpeg; *.gif; *.bmp; *.PNG";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                bm = new Bitmap(Image.FromFile(ofd.FileName));
                textBox1.Text = ofd.FileName;
                pictureBox1.Invalidate();
            }
        }
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            bm = null;
            pictureBox1.Invalidate();
        }
