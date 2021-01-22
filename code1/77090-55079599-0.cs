    internal static bool IsProcessElevatedEx(this IntPtr pHandle) {
    
            var token = IntPtr.Zero;
            var primaryToken = IntPtr.Zero;
            if (OpenProcessToken(pHandle, TOKEN_DUPLICATE, ref token)) {
                var sa = new SECURITY_ATTRIBUTES();
                sa.nLength = Marshal.SizeOf(sa);
    
                if (!DuplicateTokenEx(
                    token,
                    TokenAccessLevels.MaximumAllowed.GetHashCode(),
                    ref sa,
                    (int)SECURITY_IMPERSONATION_LEVEL.SecurityIdentification,
                    (int)TOKEN_TYPE.TokenPrimary,
                    ref primaryToken))
                    throw new Win32Exception(Marshal.GetLastWin32Error(), "DuplicateTokenEx failed");
    
                CloseHandle(token);
            } else throw new Win32Exception(Marshal.GetLastWin32Error(), "OpenProcessToken failed");
    
            WindowsIdentity identity = new WindowsIdentity(primaryToken);
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            bool result = principal.IsInRole(WindowsBuiltInRole.Administrator)
                       || principal.IsInRole(0x200); //Domain Administrator
            CloseHandle(primaryToken);
            return result;
    }
