    void Session_OnStart() {
        if (Session.IsNewSession = false )
        {
        }
        else 
        {
            Server.Transfer("SessionExpired.aspx", False);
        }
    }
