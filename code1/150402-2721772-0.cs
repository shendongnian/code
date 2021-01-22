    protected void ChangePassword1_ChangingPassword(object sender, LoginCancelEventArgs e)
    {
        // do your lookup here, 
        bool passwordHasBeenPreviouslyUsed = true;
    
    
        var pwd = (System.Web.UI.WebControls.ChangePassword)sender;
    
        if (passwordHasBeenPreviouslyUsed)
        {
            e.Cancel = true;
            // notify of error
            return;
        }
    
    }
