	internal static class App
	{
		[STAThread]
		private static void Main(string[] args)
		{
			try
			{
				Thing.Startup();
				Application.Run();
			}
			finally
			{
				Thing.Sgutdown(); // or dispose
			}
		}
	}
