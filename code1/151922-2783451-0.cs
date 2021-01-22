	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			ApplicationActions.ExitApplication = Application.Exit;
			MainPresenter mainPresenter = new MainPresenter(new MainView(), new Model());
			mainPresenter.Start();
			Application.Run(); 
		}
	}
	public static class ApplicationActions
	{
		public static Action ExitApplication { get; internal set; }
	}
	public class MainPresenter : Presenter
	{
		//...
		public override void Stop()
		{
			base.Stop();
			ApplicationActions.ExitApplication();
		}
	}
