    void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.
            if (Application[UserMan.UserID] != null)
            {
                if (Convert.ToString(Application[UserMan.UserID]) == UserMan.UserID)
                {                    
                    Application.Contents.Remove(UserMan.UserID);
                }
            }
        }
