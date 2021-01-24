    public void VideoSelected(object sender, VideoSelectionArgs e)
    {
        mediaPlayerElement.MediaPlayer.Source = e.Source;
        mediaPlayerElement.MediaPlayer.RealTimePlayback = true;
        mediaPlayerElement.MediaPlayer.Play();
    }
