          Session["USER"] = User.Identity.Name.ToString();
          Session["LOGIN"] = RemoveDomainPrefix(User.Identity.Name.ToString()); // not a real function :D
          string ldappath = "LDAP://your_ldap_path";
          // "LDAP://CN=<group name>, CN =<Users>, DC=<domain component>, DC=<domain component>,..."
          Session["cn"] = GetAttribute(ldappath, (string)Session["LOGIN"], "cn");
          Session["displayName"] = GetAttribute(ldappath, (string)Session["LOGIN"], "displayName");
          Session["mail"] = GetAttribute(ldappath, (string)Session["LOGIN"], "mail");
          Session["givenName"] = GetAttribute(ldappath, (string)Session["LOGIN"], "givenName");
          Session["sn"] = GetAttribute(ldappath, (string)Session["LOGIN"], "sn");
    public static string GetAttribute(string ldappath, string sAMAccountName, string attribute)
        {
            string OUT = string.Empty;
            try
            {
                DirectoryEntry de = new DirectoryEntry(ldappath);
                DirectorySearcher ds = new DirectorySearcher(de);
                ds.Filter = "(&(objectClass=user)(objectCategory=person)(sAMAccountName=" + sAMAccountName + "))";
                
                SearchResultCollection results = ds.FindAll();
                foreach (SearchResult result in ds.FindAll())
                {
                    OUT =  GetProperty(result, attribute);
                }
            }
            catch (Exception t)
            {
                // System.Diagnostics.Debug.WriteLine(t.Message);
            }
            return (OUT != null) ? OUT : string.Empty;
        }
    public static string GetProperty(SearchResult searchResult, string PropertyName)
        {
            if (searchResult.Properties.Contains(PropertyName))
            {
                return searchResult.Properties[PropertyName][0].ToString();
            }
            else
            {
                return string.Empty;
            }
        }
