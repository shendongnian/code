    class SoundPlayer
    {
        private static List<SoundPlayer> playing = new List<SoundPlayer>();
        public void Play(...)
        {
            ...
            playing.Add(this);
        }
        // assuming this is your callback when playing has finished
        public void OnPlayingFinished(...)
        {
            ...
            playing.Remove(this);
        }
    }
