       int numberOfFrames = 0;
       int currentFrame = 0;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Paint += new PaintEventHandler(this.pictureBox1_Paint);
            FrameDimension dimension = new FrameDimension(this.pictureBox1.Image.FrameDimensionsList[0]);
            numberOfFrames = this.pictureBox1.Image.GetFrameCount(dimension);
        }
        private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if(currentFrame == numberOfFrames)
            {
                this.pictureBox1.Enabled = false;
            }
            currentFrame++;
        }
