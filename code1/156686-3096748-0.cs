    public void Unlock(string userDn)
    {
        try
        {
            DirectoryEntry uEntry = new DirectoryEntry(userDn);
            uEntry.Properties["LockOutTime"].Value = 0; //unlock account
    
            uEntry.CommitChanges(); //may not be needed but adding it anyways
    
            uEntry.Close();
        }
        catch (System.DirectoryServices.DirectoryServicesCOMException E)
        {
            //DoSomethingWith --> E.Message.ToString();
    
        }
    }
