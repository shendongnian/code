    public partial class VLCControl : UserControl
    {
        public VLCControl()
        {
            InitializeComponent();
            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string platform = Environment.Is64BitProcess ? "x64" : "x86";
            var dirPath = System.IO.Path.Combine(currentDirectory, "vlclib", platform);
            vlc.MediaPlayer.VlcLibDirectory = new DirectoryInfo(dirPath);
            vlc.MediaPlayer.EndInit();
        }
    
        public void Play()
        {
            if (vlc.IsInitialized && !String.IsNullOrWhiteSpace(FilePath))
            {
                var options = new string[]
                {
                    String.Format("input-repeat={0}", Repeat)
                };
                vlc.MediaPlayer.SetMedia(new Uri(FilePath), options);
    
                if (!String.IsNullOrWhiteSpace(AspectRatio))
                    vlc.MediaPlayer.Video.AspectRatio = AspectRatio;
    
                vlc.MediaPlayer.Play();
            }
        }
    
        public void Stop()
        {
            vlc.MediaPlayer.Stop();
        }
    
        public string AspectRatio
        {
            get { return (string)GetValue(AspectRatioProperty); }
            set { SetValue(AspectRatioProperty, value); }
        }
    
        public static readonly DependencyProperty AspectRatioProperty =
            DependencyProperty.Register("AspectRatio", typeof(string), typeof(VLCControl));
    
    
        public string FilePath
        {
            get { return (string)GetValue(FilePathProperty); }
            set { SetValue(FilePathProperty, value); }
        }
    
        public static readonly DependencyProperty FilePathProperty =
            DependencyProperty.Register("FilePath", typeof(string), typeof(VLCControl));
    
    
        public int Repeat
        {
            get { return (int)GetValue(RepeatProperty); }
            set { SetValue(RepeatProperty, value); }
        }
    
        public static readonly DependencyProperty RepeatProperty =
            DependencyProperty.Register("Repeat", typeof(int), typeof(VLCControl), new PropertyMetadata(-1));
    
        private void vlc_Loaded(object sender, RoutedEventArgs e)
        {
            Play();
        }
    }
