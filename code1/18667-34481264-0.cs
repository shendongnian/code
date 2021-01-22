     private bool IsValidActiveDirectoryUser(string activeDirectoryServerDomain, string username, string password)
        {
            try
            {
                DirectoryEntry de = new DirectoryEntry("LDAP://" + activeDirectoryServerDomain, username + "@" + activeDirectoryServerDomain, password, AuthenticationTypes.Secure);
                DirectorySearcher ds = new DirectorySearcher(de);
                ds.FindOne();
                return true;
            }
            catch //(Exception ex)
            {
                return false;
            }
        }
