    private void Settings_Click(object sender, EventArgs e)
    {
        if (captureDevice.ShowDialog(this) == DialogResult.OK)
        {
            settings.VideoSource = captureDevice.VideoDevice;
        }
    }
    private void Start_Click(object sender, EventArgs e)
    {
        FinalVideo = settings.VideoSource;
        FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
        FinalVideo.Start();
    }
