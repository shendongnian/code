    public class VideoSelectionArgs : EventArgs
    {
        public MediaSource Source { get; private set; }
        public VideoSelectionArgs(MediaSource source)
        {
            this.Source = source;
        }
    }
