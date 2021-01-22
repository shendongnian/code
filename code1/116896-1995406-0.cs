    public StringCollection GetGroupMembers(string strDomain, string strGroup)
    {
        StringCollection groupMemebers = new StringCollection();
        try
        {
            DirectoryEntry ent = new DirectoryEntry("LDAP://DC=" + strDomain + ",DC=com");
    
            DirectorySearcher srch = new DirectorySearcher();
            // build the LDAP filter from your (CN=strGroup) part that you had
            // in the constructor, plus that filter you used in the AD tool
            // to "AND" those together, use the LDAP filter syntax:
            //  (&(condition1)(condition2))  
            srch.Filter = string.Format("(&(CN={0})(memberOf=CN=AccRght,OU=Groups,OU=P,OU=Server,DC=mydomain,DC=com)(objectCategory=user)(objectClass=user)(l=City))", strGroup);
            SearchResultCollection coll = srch.FindAll();
    
            foreach (SearchResult rs in coll)
            {
                ResultPropertyCollection resultPropColl = rs.Properties;
                foreach( Object memberColl in resultPropColl["member"])
                {
                    DirectoryEntry gpMemberEntry = new DirectoryEntry("LDAP://" + memberColl);
                    System.DirectoryServices.PropertyCollection userProps = gpMemberEntry.Properties;
                    object obVal = userProps["sAMAccountName"].Value;
                    if (null != obVal)
                    {
                        groupMemebers.Add(obVal.ToString());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
        return groupMemebers;
    }
