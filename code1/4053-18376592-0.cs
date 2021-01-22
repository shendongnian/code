    class App : WindowsFormsApplicationBase
    {
        protected override void OnCreateSplashScreen()
        {
            this.MinimumSplashScreenDisplayTime = 3000; // milliseconds
            this.SplashScreen = new Splash();
        }
        protected override void OnCreateMainForm()
        {
            this.MainForm = new Form1();
        }
    }
