     sealed partial class App : Application
    {
        public List<AB> absList = new List<AB>();
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }
