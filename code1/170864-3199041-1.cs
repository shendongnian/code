    [DllImport("advapi32.dll")]
    public static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, out IntPtr phToken);
    [DllImport("kernel32.dll")]
    public static extern bool CloseHandle(IntPtr hObject);
    public static Stream OpenFileWithAccount(string filename, string username, string domain, string password)
    {
        IntPtr token;
        if (!LogonUser(username, domain, password, 2, 0, out token))
        {
            throw new Win32Exception();
        }
        try
        {
            using (WindowsIdentity.Impersonate(token))
            {
                return File.OpenRead(filename);
            }
        }
        finally
        {
            CloseHandle(token);
        }
    }
