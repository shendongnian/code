    public class BootStrapper
    {
        SplashScreen Splash = new SplashScreen();
        MainWindow MainWindow = new MainWindow();
        public void Start()
        {
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += (s, e) =>
            {
                Splash.Close();
                MainWindow.Show();
                timer.Stop();
            };
            timer.Start();
            Splash.Show();
        }
    }
