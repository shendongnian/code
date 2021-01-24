    protected void Page_Load(object sender, EventArgs e)
    {
        // Simulate Session ID coming in from VB6...
        string sessionId;
        Random rnd = new Random();
        sessionId = "asdfghjklqwertyuiop12345" [24 char - a to z (small) & 0-5]
        // Set new session variable and copy variable from old session to new location
        ReGenerateSessionId(sessionId);
    
        // Put something into the session
        HttpContext.Current.Session["SOME_SESSION_VARIABLE_NAME"] = "Consider it done!";
    }
