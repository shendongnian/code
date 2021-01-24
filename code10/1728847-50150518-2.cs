    private TimeSpan TotalTime;
    private DispatcherTimer MediaTimer;
    private void CurrentMediaPlayer_MediaOpened(object sender, RoutedEventArgs e)
    {
        TotalTime = CurrentMediaPlayer.MediaElement.NaturalDuration.TimeSpan;
        MediaTimer = new DispatcherTimer();
        
        MediaTimer.Interval = TimeSpan.FromSeconds(1);
        //If 1 second is too slow, change this to: TimeSpan.FromMilliseconds(250)
        MediaTimer.Tick += new EventHandler(MediaTimer_Tick);
        MediaTimer.Start();
    }
    private void MediaTimer_Tick(object sender, EventArgs e)
    {
        if (CurrentMediaPlayer.MediaElement.NaturalDuration.TimeSpan.TotalSeconds > 0)
        {
            if (TotalTime.TotalSeconds > 0)
            {
                sMovieSkipSlider.Value = CurrentMediaPlayer.MediaElement.Position.TotalSeconds /
                                       TotalTime.TotalSeconds;
            }
        }
    }
