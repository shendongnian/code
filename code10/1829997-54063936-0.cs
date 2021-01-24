    public sealed partial class MainPage : Page
    {
        public AppViewModel ViewModel { get; set; } = new AppViewModel();
        public static MainPage Current { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            Current = this;
        }
    }
