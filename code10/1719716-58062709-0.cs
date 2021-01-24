    public Boolean IsAuthenticated(string username, string password,string domain)
    {
        Boolean authenticated = false;
	    //pass the connectionString here
        using (LdapConnection connection = new LdapConnection(connectionString))
        {
           try
           {
               username = username + domain;
               connection.AuthType = AuthType.Basic;
               connection.SessionOptions.ProtocolVersion = 3;
               var credential = new NetworkCredential(username, password);
               connection.Bind(credential);
               authenticated = true;
               return authenticated;
           }
           catch (LdapException)
           {
               return authenticated;
           }
           finally
           {
               connection.Dispose();
           }
       }}
