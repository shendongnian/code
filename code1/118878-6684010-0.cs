		protected void Page_Load(object sender, EventArgs e)
		{
			string username = "user";
			string password = "password";
			string server = "<boe server>";
			string auth_type = "<auth type>";
			// e.g. string auth_type = "Windows AD"
			string token; string tokenEncoded; 
			int reportid = <reportid>; 
			string report_params = "<param1>=<value1>&<param2>=<value2>";
			// logon
			SessionMgr session_mgr = new SessionMgr();
			EnterpriseSession session = session_mgr.Logon(username, password, server, auth_type);
			// create token from session manager
			token = session.LogonTokenMgr.CreateLogonTokenEx("", 120, 100);
			tokenEncoded = HttpUtility.UrlEncode(token);
			// pass the token to the custom bypass page on the CRS
			string url = string.Format("http://{0}/OpenDocument/opendoc/openDocument.aspx?sIDType=wid&iDocID={1}&lsS{2}&token={3}",
				server, reportid, param, tokenEncoded);
			Response.Redirect(url);
		}
