			using System.DirectoryServices;
			// Impersonate the Admin to Reset the Password / Unlock Account //
			// Change variables below.
			ImpersonateUser iu = new ImpersonateUser();
            if (iu.impersonateValidUser("AdminUserName", "DomainName", "AdminPassword"))
            {
                resetPassword("AdminUserName", "AdminPassword", UserToReset, "NewPassword");
                iu.undoImpersonation();
            }
			
			// Perform the Reset / Unlock //
			public void resetPassword(string username, string password, string acct, string newpassword)
			{
                string Path = // LDAP Connection String
                string Username = username;
                string Password = password;
                string Domain = "DomainName\\"; // Change to your domain name
                DirectoryEntry de = new DirectoryEntry(Path, Domain + Username, Password, AuthenticationTypes.Secure);
                DirectorySearcher ds = new DirectorySearcher(de);
                ds.Filter = "(&(objectClass=user)(|(sAMAccountName=" + acct + ")))";
                ds.PropertiesToLoad.Add("displayName");
                ds.PropertiesToLoad.Add("sAMAccountName");
                ds.PropertiesToLoad.Add("DistinguishedName");
                ds.PropertiesToLoad.Add("CN");
                SearchResult result = ds.FindOne();
                string dn = result.Properties["DistinguishedName"][0].ToString();
                DirectoryEntry uEntry = new DirectoryEntry("LDAP://" + dn, username, password);
                uEntry.Invoke("SetPassword", new object[] { newpassword });
                uEntry.Properties["LockOutTime"].Value = 0;
                uEntry.CommitChanges();
                uEntry.Close();
			}
