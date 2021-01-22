    private WindowsIdentity GetIdentity( string userName, string password )
    {
        _userToken = IntPtr.Zero;
        if ( !WindowsAPI.LogonUser(
            userName,
            AbbGrainDomain,
            password,
            WindowsAPI.LOGON32_LOGON_INTERACTIVE, WindowsAPI.LOGON32_PROVIDER_DEFAULT,
            ref _userToken
        ) )
        {
            int errorCode = Marshal.GetLastWin32Error();
            throw new System.ComponentModel.Win32Exception( errorCode );
        }
        return new WindowsIdentity( _userToken );
    }
