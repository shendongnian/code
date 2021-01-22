	protected void Application_BeginRequest(Object sender, EventArgs e) 
	{
		// Fix incorrect URL encoding by buggy BlueCoat proxy servers:
		if (!String.IsNullOrEmpty(Request.ServerVariables["HTTP_X_BLUECOAT_VIA"]))
		{
			string original = Request.QueryString.ToString();
			
			if (original.Contains(Server.UrlEncode("amp;"))) 
			{
				HttpContext.Current.RewritePath(Request.Path + "?" + original.Replace(Server.UrlEncode("amp;"), "&"));
			}
		}
	}
