        using Windows.UI.Xaml;
        public partial class SlashScreen : ContentPage
        {
            DispatcherTimer  = new DispatcherTimer();
            int _timerSecound = 5;
            public SlashScreen()
            {
                InitializeComponent();
            }
            protected override void OnAppearing()
            {
                timer.Interval= new TimeSpan(0, 0, 1);;
                timer.Tick += (obj, args) =>
                {
                        _timerSecound --;
                        timeSecound.Text = _timerSecound.ToString();
                        if (_timerSecound <=0){ 
                        /// your code here, 
                        // i dont know if you could create a new mainpage, this should not work.
                        Application.Current.MainPage = new MainPage();
                        timer.Stop();
                        // dont know if this will work for you, but this will close 
                        // the current and go back too the prev screen
                        this.Navigation.PopAsync ();
                        this.Navigation.PopToRootAsync();
                      }
                };
                timer.Start();
            }
        }
