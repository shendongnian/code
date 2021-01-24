	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			var window = new MainWindow();
            var vm = new MainViewModel();
            window.DataContext = vm;
            window.Show();
		}
	}
