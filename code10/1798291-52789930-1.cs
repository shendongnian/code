    // We need to add Microsoft.VisualBasic reference for type 
    // WindowsFormsApplicationBase.
    class SplashScreenUsingVBFramework : WindowsFormsApplicationBase
    {
        protected override void OnCreateSplashScreen()
        {
            base.OnCreateSplashScreen();
            // You can replace the Splash2 screen to yours.
            this.SplashScreen = new CSWinFormSplashScreen.SplashScreen2();
        }
        protected override void OnCreateMainForm()
        {
            base.OnCreateMainForm();
            // Here you can specify the MainForm you want to start.
            Login_From fLogin = new Login_From();
            if (fLogin.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new DashBoardForm());
            }
            else 
            {
                Application.Exit();
            }
        }
    }
