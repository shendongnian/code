	namespace WpfApp1
	{
		public partial class App : Application
		{
			protected override async void OnStartup(StartupEventArgs e)
			{
				SplashScreen.Show("Authenticating");
				await Authenticate();
				SplashScreen.Close();
				MainWindow = new MainWindow();
				MainWindow.Show();
			}
		}
	}
