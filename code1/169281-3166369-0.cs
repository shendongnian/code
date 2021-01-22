            public OutlookFolders(string exchangeUser, string mailServer)
            {
                var session = new RDOSessionClass();
                var userFullName = GetFullName("DOMAIN-NT\\" + Environment.UserName);
                session.LogonExchangeMailbox(userFullName, mailServer);
                session.Stores.FindExchangePublicFoldersStore();
                var store = session.GetSharedMailbox(exchangeUser);
                rootFolder = store.GetDefaultFolder((rdoDefaultFolders)OlDefaultFolders.olFolderContacts);
            }
    
            public static string GetFullName(string strLogin)
            {
                string str = "";
                string strDomain;
                string strName;
    
                // Parse the string to check if domain name is present.
                int idx = strLogin.IndexOf('\\');
                if (idx == -1)
                {
                    idx = strLogin.IndexOf('@');
                }
    
                if (idx != -1)
                {
                    strDomain = strLogin.Substring(0, idx);
                    strName = strLogin.Substring(idx + 1);
                }
                else
                {
                    strDomain = Environment.MachineName;
                    strName = strLogin;
                }
    
                DirectoryEntry obDirEntry = null;
                try
                {
                    obDirEntry = new DirectoryEntry("WinNT://" + strDomain + "/" + strName);
                    PropertyCollection coll = obDirEntry.Properties;
                    object obVal = coll["FullName"].Value;
                    str = obVal.ToString();
                }
                catch (System.Exception ex)
                {
                    str = ex.Message;
                }
                return str;
            }
