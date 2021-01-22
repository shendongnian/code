    IntPtr token;
    if (!NativeMethods.LogonUser(
        this.userName,
        this.domain,
        this.password,
        NativeMethods.LogonType.NewCredentials,
        NativeMethods.LogonProvider.Default,
        out token))
    {
        throw new Win32Exception();
    }
    try
    {
        IntPtr tokenDuplicate;
        if (!NativeMethods.DuplicateToken(
            token,
            NativeMethods.SecurityImpersonationLevel.Impersonation,
            out tokenDuplicate))
        {
            throw new Win32Exception();
        }
        try
        {
            using (WindowsImpersonationContext impersonationContext =
                new WindowsIdentity(tokenDuplicate).Impersonate())
            {
                // Do stuff with your share here.
                impersonationContext.Undo();
                return;
            }
        }
        finally
        {
            if (tokenDuplicate != IntPtr.Zero)
            {
                if (!NativeMethods.CloseHandle(tokenDuplicate))
                {
                    // Uncomment if you need to know this case.
                    ////throw new Win32Exception();
                }
            }
        }
    }
    finally
    {
        if (token != IntPtr.Zero)
        {
            if (!NativeMethods.CloseHandle(token))
            {
                // Uncomment if you need to know this case.
                ////throw new Win32Exception();
            }
        }
    }
