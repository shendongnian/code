    private bool _Comparing = false;
    private string _URL = "http://xcastradio.com/stats/nowplaying.txt";
    private string _data = "";
    public void CompareStrings()
    {
        Timer timer = new Timer();
        timer.Interval = 1000;
        timer.Tick += timer_Tick;
        _data = GetData(_URL);
        _Comparing = true;
        timer.Start();
    }
    void timer_Tick(object sender, EventArgs e)
    {
        if (_Comparing)
        {
            string newdata = GetData(_URL);
            if (newdata != _data)
            {
                NowPlaying np = new NowPlaying();
                NowPlayingInfo1.Text = newdata;
                _data = newdata;
                np.Show(this);
            }
        }
        else
        {
            Timer timer = (Timer)sender;
            timer.Stop();
        }
    }
