	private void Application_Startup(object sender, StartupEventArgs e)
	{
		WebClient web = new WebClient();
		web.DownloadStringCompleted += (s, args) =>
		{
			// Do stuff with args.Result);
			this.RootVisual = new Summary();
		};
		web.DownloadStringAsync(new Uri("SomeUrl.txt", UriKind.Relative));
	}
