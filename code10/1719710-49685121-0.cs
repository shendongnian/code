    public bool ValidateUser(string domainName, string username, string password)
    {
       string userDn = $"{username}@{domainName}";
       try
       {
          using (var connection = new LdapConnection {SecureSocketLayer = false})
          {
             connection.Connect(domainName, LdapConnection.DEFAULT_PORT);
             connection.Bind(userDn, password);
             if (connection.Bound)
                return true;
          }
       }
       catch (LdapException ex)
       {
          // Log exception
       }
       return false;
    }
