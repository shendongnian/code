    protected void Application_Error(object sender, EventArgs e)
            {
                //Get last error
                Exception ex = Server.GetLastError();
                ex = ex.GetBaseException();
    
                //display error to user
                Context.AddError(ex);
                Server.Transfer("Error.aspx", true);
    
            }
