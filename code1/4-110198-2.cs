    private void Form1_Load(object sender, System.EventArgs e)
    {
        TrackBar1.Minimum = 20;
        TrackBar1.Maximum = 100;
        TrackBar1.LargeChange = 10;
        TrackBar1.SmallChange = 1;
        TrackBar1.TickFrequency = 5;
    }
    private void TrackBar1_Scroll(object sender, System.EventArgs e)
    {
        this.Opacity = TrackBar1.Value / 100;
    }
