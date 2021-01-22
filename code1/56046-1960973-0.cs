    public partial class Main : Window
    {
        MediaPlayer MPlayer;
        MediaTimeline MTimeline;
        public Main()
        {
            InitializeComponent();
            var uri = new Uri("C:\\Test.mp3");
            MPlayer = new MediaPlayer();
            MTimeline = new MediaTimeline(uri);
            MTimeline.CurrentTimeInvalidated += new EventHandler(MTimeline_CurrentTimeInvalidated);
            MPlayer.Clock = MTimeline.CreateClock(true) as MediaClock;
            MPlayer.Clock.Controller.Stop();
        }
        void MTimeline_CurrentTimeInvalidated(object sender, EventArgs e)
        {
            Console.WriteLine(MPlayer.Clock.CurrentTime.Value.TotalSeconds);
        }
        private void btnPlayPause_Click(object sender, RoutedEventArgs e)
        {
            //Is Active
            if (MPlayer.Clock.CurrentState == ClockState.Active)
            {
                //Is Paused
                if (MPlayer.Clock.CurrentGlobalSpeed == 0.0)
                    MPlayer.Clock.Controller.Resume();
                else //Is Playing
                    MPlayer.Clock.Controller.Pause();
            }
            else if (MPlayer.Clock.CurrentState == ClockState.Stopped) //Is Stopped
                MPlayer.Clock.Controller.Begin();
        }
    }
