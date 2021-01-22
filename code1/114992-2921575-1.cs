    public string CreateContact(string ldapPath, string userName, 
        string userEmail)
    {
        string oGUID = string.Empty;
        try
        {            
            string connectionPrefix = "LDAP://" + ldapPath;
            DirectoryEntry dirEntry = new DirectoryEntry(connectionPrefix);
            DirectoryEntry newUser = dirEntry.Children.Add
                ("CN=" + userName, "contact");
            newUser.Properties["DisplayName"].Value = userName;
			
			//important attributs are
			newUser.Properties["targetAddress"].Value = "SMTP:" + userEmail;
			newUser.Properties["mailNickname"].Value = userName;
			
			// I'm still trying to figureout what shoud I use here!
			newUser.Properties["showInAddressBook"].Value = ???;
			
            newUser.CommitChanges();
			oGUID = newUser.Guid.ToString();
            dirEntry.Close();
            newUser.Close();
        }
        catch (System.DirectoryServices.DirectoryServicesCOMException E)
        {
            //DoSomethingwith --> E.Message.ToString();
            //MessageBox.Show(E.Message);    
        }
        return oGUID;
    }
