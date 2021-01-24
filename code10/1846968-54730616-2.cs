    public partial class SlashScreen : ContentPage
    {
        System.Timers.Timer timer = new System.Timers.Timer();
        int _timerSecound = 5;
        public SlashScreen()
        {
            InitializeComponent();
            timer.Start();
        }
        protected override void OnAppearing()
        {
            timer.Interval=1000;
            timer.Enabled=true;
            timer.Elapsed += (obj, args) =>
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
        }
    }
> Xml <Label TextColor="Black" x:Name="timeSecound" FontSize= "20"/>
