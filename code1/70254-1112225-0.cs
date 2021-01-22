        string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        string ldapPath = "LDAP://domain.company.com";
        public string GetEmail(string userName, string ldapPath)
        {
            using (DirectoryEntry root = new DirectoryEntry(ldapPath))
            {
                DirectorySearcher searcher = new DirectorySearcher(root);
                searcher.Filter = string.Format(@"(&(sAMAccountName={0}))", userName);
                searcher.PropertiesToLoad = "mail";
                SearchResult result = searcher.FindOne();
                if (result != null)
                {
                    PropertyValueCollection property = result.Properties["mail"];
                    return (string)property.Value;
                }
                else
                { 
                    // something bad happened
                }
            }
        }
