    public Form1() // init
    {
        InitializeComponent();
        {
            VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in VideoCaptureDevices)
            {
                comboBox1.Items.Add(VideoCaptureDevice.Name);
            }
            comboBox1.SelectedIndex = 0;
        }
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        FinalVideo = new VideoCaptureDevice(VideoCaptureDevices[comboBox1.SelectedIndex].MonikerString);
        FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
        FinalVideo.Start();
    }
    
    void FinalVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
    {
        Bitmap video = (Bitmap)eventArgs.Frame.Clone();
        pictureBox1.Image = video;
    
    }
    
    private void button2_Click(object sender, EventArgs e)
    {
        FinalVideo.Stop();
    }
    }
