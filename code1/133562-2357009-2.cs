    if (machineID.Count != 0)
                {
    
                    checkMachineGrpState(machineID);
            else
                    {
                       GoSignOut();
                      Page.ClientScript.RegisterStartupScript(this.GetType(), "Redirect", "<script>alert('You are being logged out');window.location.href('" + ResolveUrl("~/Default.aspx") + "')</script>");
                    }
        }
    
     private void GoSignout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
        }
