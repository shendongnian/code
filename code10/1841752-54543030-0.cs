    public Form1()
        {
            InitializeComponent();
        }
        private BackgroundWorker CreateBackgroundWorker()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += ReadFrames;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            return worker;
        }
        private void worker_RunWorkerCompleted(object sender,
            RunWorkerCompletedEventArgs e)
        {
            Button playButton = (Button) e.Result;
            playButton.Enabled = true;
        }
        private void ReadFrames(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = (BackgroundWorker) sender;
            (string path, PictureBox pictureBox, Button playButton) arguments = ((string, PictureBox, Button)) e.Argument;
            using(var vFReader = new VideoFileReader())
            {
                vFReader.Open(arguments.path);
                for (int i = 0; i < vFReader.FrameCount; i++)
                {
                    arguments.pictureBox.Image = new Bitmap(vFReader.ReadVideoFrame(), arguments.pictureBox.Size);
                }
                vFReader.Dispose();
                vFReader.Close();
            }
            e.Result = arguments.playButton;
        }
        private void play1_Click(object sender, EventArgs e)
        {
            var worker = CreateBackgroundWorker();
            worker.RunWorkerAsync((textBox1.Text, pictureBox1, play1));
            play1.Enabled = false;
        }
        private void play2_Click(object sender, EventArgs e)
        {
            var worker = CreateBackgroundWorker();
            worker.RunWorkerAsync((textBox2.Text, pictureBox2, play2));
            play2.Enabled = false;
        }
        private void play3_Click(object sender, EventArgs e)
        {
            var worker = CreateBackgroundWorker();
            worker.RunWorkerAsync((textBox3.Text, pictureBox3, play3));
            play3.Enabled = false;
        }
        private void play4_Click(object sender, EventArgs e)
        {
            var worker = CreateBackgroundWorker();
            worker.RunWorkerAsync((textBox4.Text, pictureBox4, play4));
            play4.Enabled = false;
        }
