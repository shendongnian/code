    public sealed partial class VideoPlayer : UserControl
    {
        public VideoPlayer()
        {
            this.InitializeComponent();
        }
        public void setSourc(string link)
        {
            player.AutoPlay = false;
            player.Source = MediaSource.CreateFromUri(new Uri(link));
            player.MediaPlayer.Play();
        }
        public async void pause()
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                player.MediaPlayer.Dispose();
            });
        }
        public double Duration()
        {
            double result = 0;
            try
            {
                result = player.MediaPlayer.NaturalDuration.TotalSeconds;
            }
            catch { }
            return result;
        }
        public int Time()
        {
            int result = 0;
            try
            {
                result = player.MediaPlayer.Position.Seconds;
            }
            catch { }
            return result;
        }
    }
