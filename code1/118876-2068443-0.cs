        string username = "user";
        string password = "password";
        string server = "CMSNAME:6400";
        string auth_type = "secEnterprise";
        // logon
        SessionMgr session_mgr = new SessionMgr();
        EnterpriseSession session = session_mgr.Logon(username, password, server, auth_type);
        // get the serialized session
        string session_str = session.SerializedSession;
        // pass the session to our custom bypass page on the CRS
        string url = "http://reportserver.domain.com/InfoViewApp/transfer.aspx?session="
        url += HttpUtility.UrlEncode(session_str);
        Response.Redirect(url);
