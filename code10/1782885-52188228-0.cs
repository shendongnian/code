	public partial class App : Application
	{
		public EventHandler OnResumeHandler;
		public EventHandler OnSleepHandler;
		public App()
		{
			InitializeComponent();
			MainPage = new MyPage();
		}
		protected override void OnSleep()
		{
			OnSleepHandler?.Invoke(null, new EventArgs());
		}
		protected override void OnResume()
		{
			OnResumeHandler?.Invoke(null, new EventArgs());
		}
	}
