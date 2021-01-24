    internal class Sound
    {
        public bool HasAudio { get { return mediaPlayer.HasAudio; } }
        
        private MediaPlayer mediaPlayer = new MediaPlayer();
    
        public void Play(string fileName)
        {
            mediaPlayer.Open(new Uri(@"sounds/" + fileName, UriKind.RelativeOrAbsoute));
            mediaPlayer.Play();
        }
    
        public void Stop()
        {
            mediaPlayer.Stop();
        }
    }
