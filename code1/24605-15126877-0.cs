        DirectoryEntry hostMachineDirectory = new DirectoryEntry("WinNT://localhost");
        DirectoryEntries entries = hostMachineDirectory.Children;
        bool userExists = false;
        foreach (DirectoryEntry each in entries)
        {
            userExists = each.Name.Equals("NewUser",  
            StringComparison.CurrentCultureIgnoreCase);
            if (systemtestUserExists)
                break;
        }
        if (false == userExists)
        {
            DirectoryEntry obUser = entries.Add("NewUser", "User");
            obUser.Properties["FullName"].Add("Local user");
            obUser.Invoke("SetPassword", "abcdefg12345@");
            obUser.Invoke("Put", new object[] {"UserFlags", 0x10000});
            obUser.CommitChanges();
