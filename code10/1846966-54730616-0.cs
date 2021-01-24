    public partial class SlashScreen : ContentPage
    {
        System.Timers.Timer timer = new System.Timers.Timer();
        public SlashScreen()
        {
            InitializeComponent();
            timer.Start();
        }
        protected override void OnAppearing()
        {
            timer.Interval=5000;
            timer.Enabled=true;
            timer.Elapsed += (obj, args) =>
            {
                    /// your code here
                    Application.Current.MainPage = new MainPage();
                    timer.Stop();
            };
        }
    }
