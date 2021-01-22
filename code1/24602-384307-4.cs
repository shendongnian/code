    public string CreateUserAccount(string ldapPath, string userName, 
        string userPassword)
    {
        string oGUID = string.Empty;
        try
        {          
            string connectionPrefix = "LDAP://" + ldapPath;
            DirectoryEntry dirEntry = new DirectoryEntry(connectionPrefix);
            DirectoryEntry newUser = dirEntry.Children.Add
                ("CN=" + userName, "user");
            newUser.Properties["samAccountName"].Value = userName;
            int val = (int)newUser.Properties["userAccountControl"].Value; 
            newUser.Properties["userAccountControl"].Value = val | 0x10000; 
            newUser.CommitChanges();
            oGUID = newUser.Guid.ToString();
    
            newUser.Invoke("SetPassword", new object[] { userPassword });
            newUser.CommitChanges();
 
            dirEntry.Close();
            newUser.Close();
        }
        catch (System.DirectoryServices.DirectoryServicesCOMException E)
        {
            //DoSomethingwith --> E.Message.ToString();    
        }
        return oGUID;
    }
