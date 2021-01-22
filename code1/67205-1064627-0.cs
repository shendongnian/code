    public bool IsAccountPasswordProtected(String userName)
    {
        String entryString = "WinNT://" + Environment.MachineName + ",Computer";
        DirectoryEntry dirEntry = new DirectoryEntry(entryString);
        DirectoryEntry user = dirEntry.Children.Find(userName, "User");
        int userFlags = (int)user.Properties["UserFlags"].Value;
        if ((userFlags & (int)ActiveDs.ADS_USER_FLAG.ADS_UF_PASSWD_NOTREQD) != 0)
            return false;
    
        IntPtr token;
        bool result = LogonUser(
            user.Name, Environment.UserDomainName, 
            "",
            LogonTypes.Interactive,
            LogonProviders.Default,
            out token);
        if (result)
        {
            CloseHandle(token);
            return false;
        }
        else
        {
            int err = Marshal.GetLastWin32Error();
            if (err == 1327)  // ERROR_ACCOUNT_RESTRICTION
                return false;
            //if(err == 1331) // ERROR_ACCOUNT_DISABLED
    
            return true;
        }
    }
    
    [DllImport("advapi32.dll", SetLastError = true)]
    static extern bool LogonUser(
      string principal,
      string authority,
      string password,
      LogonTypes logonType,
      LogonProviders logonProvider,
      out IntPtr token);
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool CloseHandle(IntPtr handle);
    enum LogonTypes : uint
    {
        Interactive = 2,
        Network,
        Batch,
        Service,
        NetworkCleartext = 8,
        NewCredentials
    }
    enum LogonProviders : uint
    {
        Default = 0, // default for platform (use this!)
        WinNT35,     // sends smoke signals to authority
        WinNT40,     // uses NTLM
        WinNT50      // negotiates Kerb or NTLM
    }
