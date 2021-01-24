    AVAudioPlayer _player;
    public void PlayMusic(string file)
    {
        NSError error;
        _player = new AVAudioPlayer(new NSUrl(file + ".mp3"), "mp3", out error);
        if (error != null)
        {
            Debu.WriteLine("Error in PlayTheme, {0}: {1}", file, error.LocalizedDescription);
            return;
        }
        _player.Volume = 0.6f;
        _player.NumberOfLoops = -1;
        _player.Play();
    }
    public void StopMusic()
    {
        if (_player != null)
        {
            _player.Stop();
            _player.Dispose();
            _player = null;
        }
    }
