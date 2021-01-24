            public partial class SlashScreen : ContentPage
            {
                int _timerSecound = 5;
                public SlashScreen()
                {
                    InitializeComponent();
                }
                protected override void OnAppearing()
                {
                    Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                    {
                            _timerSecound --;
                            timeSecound.Text = _timerSecound.ToString();
                            if (_timerSecound <=0){ 
                            /// your code here, 
                            // i dont know if you could create a new mainpage, this should not work.
                            Application.Current.MainPage = new MainPage();
                            // dont know if this will work for you, but this will close 
                            // the current and go back too the prev screen
                            this.Navigation.PopAsync ();
                            this.Navigation.PopToRootAsync();
                            return false; // stop
                          }
                          return true; // repeat
                    };
                }
            }
