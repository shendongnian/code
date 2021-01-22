		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
			// Allow https pages in debugging
			if (Request.IsLocal)
			{
				if (Request.Url.Scheme == "http")
				{
					int localSslPort = 44362; // Your local IIS port for HTTPS
					var path = "https://" + Request.Url.Host + ":" + localSslPort + Request.Url.PathAndQuery;
					Response.Status = "301 Moved Permanently";
					Response.AddHeader("Location", path);
				}
			}
			else
			{
				switch (Request.Url.Scheme)
				{
					case "https":
						Response.AddHeader("Strict-Transport-Security", "max-age=31536000");
						break;
					case "http":
						var path = "https://" + Request.Url.Host + Request.Url.PathAndQuery;
						Response.Status = "301 Moved Permanently";
						Response.AddHeader("Location", path);
						break;
				}
			}
		}
