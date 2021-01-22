    //Get the basic FtpWebRequest object with the
    //common settings and security
    private FtpWebRequest GetRequest(string URI)
    {
        //create request
        FtpWebRequest result = (FtpWebRequest)FtpWebRequest.Create(URI);
        //Set the login details
        result.Credentials = GetCredentials();
        //Do not keep alive (stateless mode)
        result.KeepAlive = false;
        return result;
    }
    
    /// <summary>
    /// Get the credentials from username/password
    /// </summary>
    private System.Net.ICredentials GetCredentials()
    {
        return new System.Net.NetworkCredential(Username, Password);
    }
