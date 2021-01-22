    	private static void Main(string[] args)
		{
			try
			{
				const string appguid = "{xxxxxxxx-xxxxxxxx}";
				using (new SingleAppMutexControl(appguid))
				{
					//run main app
					Console.ReadLine();
				}
			}
			catch (System.TimeoutException)
			{
				Log.Warn("Application already runned");
			}
			catch (Exception ex)
			{
				Log.Fatal(ex, "Fatal Error on running");
			}
		}
