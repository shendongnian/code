    var TFS_UserName = "UserName";
    var TFS_Pass = "Password";
    var domain = "domain";
    var tfsUri = System.Configuration.ConfigurationManager.AppSettings["TFSUri"];
    Uri uri = new Uri(tfsUri);
    NetworkCredential cred = new NetworkCredential(UserName, Password);
    TfsTeamProjectCollection tfsCollection = new TfsTeamProjectCollection(tfsUri, cred);
    try
    {
        tfsCollection.EnsureAuthenticated();
    }
    catch (Exception ex)
    {
        return "User not Authorized" + ex.Message;
    }
