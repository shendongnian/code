    private StringCollection GetUserGroupMembership(string strUser)
    {
        StringCollection groups = new StringCollection();
        try
        {
            DirectoryEntry obEntry = new DirectoryEntry(
                "LDAP://CN=users,DC=pardesifashions,DC=com");
            DirectorySearcher srch = new DirectorySearcher(obEntry, 
                "(sAMAccountName=" + strUser + ")");
            SearchResult res = srch.FindOne();
            if (null != res)
            {
                DirectoryEntry obUser = new DirectoryEntry(res.Path);
                // Invoke Groups method.
                object obGroups = obUser.Invoke("Groups");
                foreach (object ob in (IEnumerable)obGroups)
                {
                    // Create object for each group.
                    DirectoryEntry obGpEntry = new DirectoryEntry(ob);
                    groups.Add(obGpEntry.Name);
                }
            }
        }
        catch (Exception ex)
        {
            Trace.Write(ex.Message);
        }
        return groups;
    }
