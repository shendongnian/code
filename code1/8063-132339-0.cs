    public static bool IsUserInGroup(string lanid, string group)
    {
        DirectoryEntry entry = new DirectoryEntry("LDAP://" + LDAPPATH);
        if(entry != null)
        {
            entry.Username=@"LDAPUSER";
            entry.Password="LDAPPASSWORD";
            DirectorySearcher srch = new DirectorySearcher(entry);
            srch.Filter = String.Format("(&(objectClass=person)(sAMAccountName={0}))", lanid);
            srch.PropertiesToLoad.Add("memberOf");
    
            SearchResult result = srch.FindOne();
            if(result != null)
            {
                if(result.Properties.Contains("memberOf"))
                {
                    string lookfor = String.Format("cn={0},", group.ToLower());
                    foreach(string memberOf in result.Properties["memberOf"])
                    {
                        if(memberOf.ToLower().StartsWith(lookfor))
                            return true;
                    }
                }
            }
            return false;
        }
        throw new Exception(String.Format("Could not get Directory lanid:{0}, group{1}",   lanid, group));
    }
