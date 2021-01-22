    public void ResetPassword(string userDn, string password)
    {
        DirectoryEntry uEntry = new DirectoryEntry(userDn);
        uEntry.Invoke("SetPassword", new object[] { password });
        uEntry.Properties["LockOutTime"].Value = 0; //unlock account
    
        uEntry.Close();
    }
