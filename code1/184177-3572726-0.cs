		public void Init(HttpApplication context)
		{
			context.BeginRequest += new EventHandler(context_BeginRequest);
		}
		void context_BeginRequest(object sender, EventArgs e)
		{
			HttpApplication app = sender as HttpApplication;
			if (app.Context == null || app.Context.Response == null)
				return;
			String sourceUrl = String.Empty;
			try
			{
				sourceUrl = app.Request.FilePath.TrimStart('/').TrimEnd('/').ToLower();
				if (global::MyProject.Global.UrlShortcuts.ContainsKey(sourceUrl))
				{
					String newUrl = global::MyProject.Global.UrlShortcuts[sourceUrl];
					app.Context.RewritePath(newUrl, string.Empty, app.Request.QueryString.ToString(), false);
									}
				else
				{
				}
			}
			catch (Exception Ex)
			{
				// handle your exception here
			}
		}
