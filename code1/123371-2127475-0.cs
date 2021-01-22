    // [ C# ]
    WMPLib.WindowsMediaPlayer Player;
    
    private void PlayFile(String url)
    {
        Player = new WMPLib.WindowsMediaPlayer();
        Player.PlayStateChange += 
            new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);
        Player.MediaError += 
            new WMPLib._WMPOCXEvents_MediaErrorEventHandler(Player_MediaError);
        Player.URL = url;
        Player.controls.play();
    }
    
    private void Form1_Load(object sender, System.EventArgs e)
    {
        // TODO  Insert a valid path in the line below.
        PlayFile(@"c:\myaudio.wma");
    }
    
    private void Player_PlayStateChange(int NewState)
    {
        if ((WMPLib.WMPPlayState)NewState == WMPLib.WMPPlayState.wmppsStopped)
        {
            this.Close();
        }
    }
    
    private void Player_MediaError(object pMediaObject)
    {
        MessageBox.Show("Cannot play media file.");
        this.Close();
    }
