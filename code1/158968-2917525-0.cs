    public override bool ValidateUser(string username, string password)
    {
       // in membership provider
       HttpContext.Current.Items["loginFailureReason"] = "Locked Out";
       return false;
    }
    
    // in login codebehind
    protected void Login1_LoginError(object sender, EventArgs e)
     {
         Login1.FailureText = (string) HttpContext.Current.Items["loginFailureReason"];
     }
