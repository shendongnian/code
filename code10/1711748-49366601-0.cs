    public partial class App
	{
		private void App_Startup(object sender, StartupEventArgs e)
		{
			var view = new MainView { DataContext = new MainVM() };
			view.Show();
		}
	}
