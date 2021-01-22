    using System.DirectoryServices.ActiveDirectory;
    using System.DirectoryServices;
    public bool IsUserInGroup(string group, string user)
    {
        string DomainName="";
        string ADUsername="";
        string ADPassword="";
        DirectoryEntry entry=new DirectoryEntry(LDAPConnectionString, ADUsername, ADPassword);
        DirectorySearcher dSearch=new DirectorySearcher(entry);
        dSearch.Filter="(&(objectClass=user)(userPrincipalName=" + user + ")";
        foreach(SearchResult sResultSet in dSearch.FindAll())
        {
            string strGroupList=GetProperty(sResultSet, "memberOf");
            if(!string.IsNullOrEmpty(strGroupList) && strGroupList.IndexOf(group)>-1)
                return true;
        }
        return false;
    } 
