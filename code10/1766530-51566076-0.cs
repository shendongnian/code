    public sealed partial class MainPage : Page
    {
        public ObservableCollection<TimerWallpaper> TimerWallpapers { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            TimerWallpapers = new ObservableCollection<TimerWallpaper>();
            DataContext = this;
        }
    }
