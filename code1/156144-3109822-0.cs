		public const int LOGON32_LOGON_INTERACTIVE = 2;
		public const int LOGON32_PROVIDER_DEFAULT = 0;
		public bool ImpersonateUser( string userName, string domain, string password ) {
			WindowsIdentity tempWindowsIdentity;
			IntPtr token = IntPtr.Zero;
			IntPtr tokenDuplicate = IntPtr.Zero;
			if (RevertToSelf ()) {
				if (LogonUserA ( userName, domain, password, LOGON32_LOGON_INTERACTIVE,
					LOGON32_PROVIDER_DEFAULT, ref token ) != 0) {
					if (DuplicateToken ( token, 2, ref tokenDuplicate ) != 0) {
						tempWindowsIdentity = new WindowsIdentity ( tokenDuplicate );
						impersonationContext = tempWindowsIdentity.Impersonate ();
						if (impersonationContext != null) {
							CloseHandle ( token );
							CloseHandle ( tokenDuplicate );
							return true;
						}
					}
				}
			}
			if (token!= IntPtr.Zero)
				CloseHandle ( token );
			if (tokenDuplicate!=IntPtr.Zero)
				CloseHandle ( tokenDuplicate );
			return false;
		}
