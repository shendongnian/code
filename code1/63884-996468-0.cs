		/// <summary>impersonates a user</summary>
		/// <param name="username">domain\name of the user account</param>
		/// <param name="password">the user's password</param>
		/// <returns>the new WindowsImpersonationContext</returns>
		public static WindowsImpersonationContext ImpersonateUser(String username, String password)
		{
			WindowsIdentity winId = WindowsIdentity.GetCurrent();
			if (winId != null)
			{
				if (string.Compare(winId.Name, username, true) == 0)
				{
					return null;
				}
			}
			//define the handles
			IntPtr existingTokenHandle = IntPtr.Zero;
			IntPtr duplicateTokenHandle = IntPtr.Zero;
			String domain;
			if (username.IndexOf("\\") > 0)
			{
				//split domain and name
				String[] splitUserName = username.Split('\\');
				domain = splitUserName[0];
				username = splitUserName[1];
			}
			else
			{
				domain = String.Empty;
			}
			try
			{
				//get a security token
				bool isOkay = AdvApi32.LogonUser(username, domain, password,
					(int) AdvApi32.LogonTypes.LOGON32_LOGON_INTERACTIVE,
					(int) AdvApi32.LogonTypes.LOGON32_PROVIDER_DEFAULT,
					ref existingTokenHandle);
				if (!isOkay)
				{
					int lastWin32Error = Marshal.GetLastWin32Error();
					int lastError = Kernel32.GetLastError();
					throw new Exception("LogonUser Failed: " + lastWin32Error + " - " + lastError);
				}
				// copy the token
				isOkay = AdvApi32.DuplicateToken(existingTokenHandle,
					(int) AdvApi32.SecurityImpersonationLevel.SecurityImpersonation,
					ref duplicateTokenHandle);
				if (!isOkay)
				{
					int lastWin32Error = Marshal.GetLastWin32Error();
					int lastError = Kernel32.GetLastError();
					Kernel32.CloseHandle(existingTokenHandle);
					throw new Exception("DuplicateToken Failed: " + lastWin32Error + " - " + lastError);
				}
				// create an identity from the token
				WindowsIdentity newId = new WindowsIdentity(duplicateTokenHandle);
				WindowsImpersonationContext impersonatedUser = newId.Impersonate();
				return impersonatedUser;
			}
			finally
			{
				//free all handles
				if (existingTokenHandle != IntPtr.Zero)
				{
					Kernel32.CloseHandle(existingTokenHandle);
				}
				if (duplicateTokenHandle != IntPtr.Zero)
				{
					Kernel32.CloseHandle(duplicateTokenHandle);
				}
			}
		}
