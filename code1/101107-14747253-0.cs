    	/// <summary>
		/// Get the site URL (one step up from ClientBin)
		/// </summary>
		public string HostWebSite
		{
			get
			{
				string host = App.Current.Host.Source.AbsoluteUri;
				int clientBin = host.IndexOf("ClientBin", 0);
				if (clientBin == -1)
					return "Could not find \"ClientBin\" in " + host;
				return host.Substring(0, clientBin);
			}
		}
