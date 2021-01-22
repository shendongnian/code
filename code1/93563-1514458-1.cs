		public static string RunAspPage(string rootDirectory, string page, string query)
		{
			RemoteAspDomain host;
			try
			{
				host = (RemoteAspDomain)ApplicationHost.CreateApplicationHost(typeof(RemoteAspDomain), "/", rootDirectory);
				return host.ProcessRequest(page, query);
			}
			finally
			{
				ApplicationManager.GetApplicationManager().ShutdownAll();
				System.Web.Hosting.HostingEnvironment.InitiateShutdown();
				host = null;
			}
		}
