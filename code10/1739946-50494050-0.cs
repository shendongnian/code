    public partial class Form1 : Form
    {
        private int PictureBoxResize = 2;
        public Form1()
        {
            InitializeComponent();
            timer1.Tick += new EventHandler(this.timer1_Tick);
            timer1.Interval = 100;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(pictureBox1.Left - (PictureBoxResize / 2), 
                                             pictureBox1.Top - (PictureBoxResize / 2));
            pictureBox1.Size = new Size(pictureBox1.Width + PictureBoxResize, 
                                        pictureBox1.Height + PictureBoxResize);
        }
    }
