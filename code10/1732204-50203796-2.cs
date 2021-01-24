    private void Form9_Load(object sender, EventArgs e)
    {
        imges = Directory.GetFiles(@"G:\Pics");
        Timer T = new Timer();
        T.Interval = 500;
        T.Tick += new EventHandler(PlayTime);
        T.Start();
    }
