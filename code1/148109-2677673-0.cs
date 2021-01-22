        public const UInt32 TOKEN_DUPLICATE = 0x0002;
        public const UInt32 TOKEN_IMPERSONATE = 0x0004;
        public const UInt32 TOKEN_QUERY = 0x0008;
        public enum TOKEN_ELEVATION_TYPE
        {
            TokenElevationTypeDefault = 1,
            TokenElevationTypeFull,
            TokenElevationTypeLimited
        }
        public enum TOKEN_INFORMATION_CLASS
        {
            TokenUser = 1,
            TokenGroups,
            TokenPrivileges,
            TokenOwner,
            TokenPrimaryGroup,
            TokenDefaultDacl,
            TokenSource,
            TokenType,
            TokenImpersonationLevel,
            TokenStatistics,
            TokenRestrictedSids,
            TokenSessionId,
            TokenGroupsAndPrivileges,
            TokenSessionReference,
            TokenSandBoxInert,
            TokenAuditPolicy,
            TokenOrigin,
            TokenElevationType,
            TokenLinkedToken,
            TokenElevation,
            TokenHasRestrictions,
            TokenAccessInformation,
            TokenVirtualizationAllowed,
            TokenVirtualizationEnabled,
            TokenIntegrityLevel,
            TokenUIAccess,
            TokenMandatoryPolicy,
            TokenLogonSid,
            MaxTokenInfoClass  // MaxTokenInfoClass should always be the last enum 
        }
        public enum SECURITY_IMPERSONATION_LEVEL
        {
            SecurityAnonymous,
            SecurityIdentification,
            SecurityImpersonation,
            SecurityDelegation
        }
        public static bool IsAdmin()
        {
            var identity = WindowsIdentity.GetCurrent();
            return (null != identity && new WindowsPrincipal(identity).IsInRole(WindowsBuiltInRole.Administrator));
        }
        /// <summary>
        /// The function checks whether the primary access token of the process belongs
        /// to user account that is a member of the local Administrators group, even if
        /// it currently is not elevated.
        /// </summary>
        /// <returns>
        /// Returns true if the primary access token of the process belongs to user
        /// account that is a member of the local Administrators group. Returns false
        /// if the token does not.
        /// </returns>
        public static bool CanBeAdmin()
        {
            bool fInAdminGroup = false;
            IntPtr hToken = IntPtr.Zero;
            IntPtr hTokenToCheck = IntPtr.Zero;
            IntPtr pElevationType = IntPtr.Zero;
            IntPtr pLinkedToken = IntPtr.Zero;
            int cbSize = 0;
            if (IsAdmin())
                return true;
            try
            {
                // Check the token for this user
                hToken = WindowsIdentity.GetCurrent().Token;
                // Determine whether system is running Windows Vista or later operating
                // systems (major version >= 6) because they support linked tokens, but
                // previous versions (major version < 6) do not.
                if (Environment.OSVersion.Version.Major >= 6)
                {
                    // Running Windows Vista or later (major version >= 6).
                    // Determine token type: limited, elevated, or default.
                    // Allocate a buffer for the elevation type information.
                    cbSize = sizeof(TOKEN_ELEVATION_TYPE);
                    pElevationType = Marshal.AllocHGlobal(cbSize);
                    if (pElevationType == IntPtr.Zero)
                    {
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    }
                    // Retrieve token elevation type information.
                    if (!GetTokenInformation(hToken,
                        TOKEN_INFORMATION_CLASS.TokenElevationType, pElevationType, cbSize, out cbSize))
                    {
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    }
                    // Marshal the TOKEN_ELEVATION_TYPE enum from native to .NET.
                    TOKEN_ELEVATION_TYPE elevType = (TOKEN_ELEVATION_TYPE)Marshal.ReadInt32(pElevationType);
                    // If limited, get the linked elevated token for further check.
                    if (elevType == TOKEN_ELEVATION_TYPE.TokenElevationTypeLimited)
                    {
                        // Allocate a buffer for the linked token.
                        cbSize = IntPtr.Size;
                        pLinkedToken = Marshal.AllocHGlobal(cbSize);
                        if (pLinkedToken == IntPtr.Zero)
                        {
                            throw new Win32Exception(Marshal.GetLastWin32Error());
                        }
                        // Get the linked token.
                        if (!GetTokenInformation(hToken,
                            TOKEN_INFORMATION_CLASS.TokenLinkedToken, pLinkedToken,
                            cbSize, out cbSize))
                        {
                            throw new Win32Exception(Marshal.GetLastWin32Error());
                        }
                        // Marshal the linked token value from native to .NET.
                        hTokenToCheck = Marshal.ReadIntPtr(pLinkedToken);
                    }
                }
                // CheckTokenMembership requires an impersonation token. If we just got
                // a linked token, it already is an impersonation token.  If we did not
                // get a linked token, duplicate the original into an impersonation
                // token for CheckTokenMembership.
                if (hTokenToCheck == IntPtr.Zero)
                {
                    if (!DuplicateToken(hToken, (int)SECURITY_IMPERSONATION_LEVEL.SecurityIdentification, ref hTokenToCheck))
                    {
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    }
                }
                // Check if the token to be checked contains admin SID.
                WindowsIdentity id = new WindowsIdentity(hTokenToCheck);
                WindowsPrincipal principal = new WindowsPrincipal(id);
                fInAdminGroup = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch
            {
                return false;
            }
            finally
            {
                // Centralized cleanup for all allocated resources.
                if (pElevationType != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pElevationType);
                    pElevationType = IntPtr.Zero;
                }
                if (pLinkedToken != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pLinkedToken);
                    pLinkedToken = IntPtr.Zero;
                }
            }
            return fInAdminGroup;
        }
