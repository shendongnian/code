    if (ImpersonateValidUser(adConnectionUsername, adConnectionDomain, adConnectionPassword))
    {      
        DirectoryEntry deUser = new DirectoryEntry(result.Path);              
        deUser.Properties["comment"].Value = comment;
        deUser.CommitChanges();
        deUser.Close();
        UndoImpersonation();
    }
