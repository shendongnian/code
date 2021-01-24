	static void Main()
	{
		try
		{
			using (var mgr = new UpdateManager("xxxx"))
			{			
				mgr.UpdateApp().Wait();				
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
	
