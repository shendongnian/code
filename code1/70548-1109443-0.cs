    int session = Win32.WTSGetActiveConsoleSessionId();
    if (session == 0xFFFFFFFF)
    {
        return false;
    }
    
    IntPtr userToken;
    bool res = Win32.WTSQueryUserToken(session, out userToken);
    if (!res)
    {
        this.log.WriteEntry("Error WTSQueryUserToken");
        return false;
    }
    
    string path = GetPath();
    string dir = Path.GetDirectoryName(path);
    Win32.STARTUPINFO si = new Win32.STARTUPINFO();
    si.lpDesktop = "winsta0\\default";
    si.cb = Marshal.SizeOf(si);
    
    Win32.PROCESS_INFORMATION pi = new Win32.PROCESS_INFORMATION();
    Win32.SECURITY_ATTRIBUTES sa = new Win32.SECURITY_ATTRIBUTES();
    sa.bInheritHandle = 0;
    sa.nLength = Marshal.SizeOf(sa);
    sa.lpSecurityDescriptor = IntPtr.Zero;
    
    if (!Win32.CreateProcessAsUser(userToken,       // user token
                                    path,           // exexutable path
                                    string.Empty,   // arguments
                                    ref sa,         // process security attributes ( none )
                                    ref sa,         // thread  security attributes ( none )
                                    false,          // inherit handles?
                                    0,              // creation flags
                                    IntPtr.Zero,    // environment variables
                                    dir,            // current directory of the new process
                                    ref si,         // startup info
                                    out pi))        // receive process information in pi
    {
        int error = Marshal.GetLastWin32Error();
        this.log.WriteEntry("Error CreateProcessAsUser:" + error);
        return false;
    }
