	static async Task Main()
	{
		try
		{
			using (var mgr = new UpdateManager("xxxx"))
			{
				await mgr.UpdateApp();
			}
		}
		catch (Exception ex)
		{
			logger.Debug(ex.Message);
		}
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(false);
		Application.Run(new XForm());
	}
	
