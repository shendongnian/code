    private void SendToFileShare(byte[] pdfData, string fileName)
	{
		if(pdfData == null)
		{
			throw new ArgumentNullException("pdfData");
		}
		if (string.IsNullOrWhiteSpace(fileName))
		{
			//Assign a unique name because the programmer failed to specify one.
			fileName = Guid.NewGuid().ToString();
		}
		else
		{
			//Should probably replace special characters (windows filenames) with something.                
		}
		string networkShareLocation = @"\\your\network\share\";
					
		var path = $"{networkShareLocation}{fileName}.pdf";
		
		//Credentials for the account that has write-access. Probably best to store these in a web.config file.
		var domain = "AB";
		var userID = "Mr";
		var password = "C";
		
		
		if (ImpersonateUser(domain, userID, password) == true)
		{
			//write the PDF to the share:
			System.IO.File.WriteAllBytes(path, report);
			
			undoImpersonation();
		}
		else
		{
			//Could not authenticate account. Something is up.
			//Log or something.
		}
	}
	/// <summary>
	/// Impersonates the given user during the session.
	/// </summary>
	/// <param name="domain">The domain.</param>
	/// <param name="userName">Name of the user.</param>
	/// <param name="password">The password.</param>
	/// <returns></returns>
	private bool ImpersonateUser(string domain, string userName, string password)
	{
		WindowsIdentity tempWindowsIdentity;
		IntPtr token = IntPtr.Zero;
		IntPtr tokenDuplicate = IntPtr.Zero;
		if (RevertToSelf())
		{
			if (LogonUserA(userName, domain, password, LOGON32_LOGON_INTERACTIVE,
				LOGON32_PROVIDER_DEFAULT, ref token) != 0)
			{
				if (DuplicateToken(token, 2, ref tokenDuplicate) != 0)
				{
					tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
					impersonationContext = tempWindowsIdentity.Impersonate();
					if (impersonationContext != null)
					{
						CloseHandle(token);
						CloseHandle(tokenDuplicate);
						return true;
					}
				}
			}
		}
		if (token != IntPtr.Zero)
			CloseHandle(token);
		if (tokenDuplicate != IntPtr.Zero)
			CloseHandle(tokenDuplicate);
		return false;
	}
	/// <summary>
	/// Undoes the current impersonation.
	/// </summary>
	private void undoImpersonation()
	{
		impersonationContext.Undo();
	}
	
	#region Impersionation global variables
	public const int LOGON32_LOGON_INTERACTIVE = 2;
	public const int LOGON32_PROVIDER_DEFAULT = 0;
	WindowsImpersonationContext impersonationContext;
	[DllImport("advapi32.dll")]
	public static extern int LogonUserA(String lpszUserName,
		String lpszDomain,
		String lpszPassword,
		int dwLogonType,
		int dwLogonProvider,
		ref IntPtr phToken);
	[DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern int DuplicateToken(IntPtr hToken,
		int impersonationLevel,
		ref IntPtr hNewToken);
	[DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern bool RevertToSelf();
	[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
	public static extern bool CloseHandle(IntPtr handle);
	#endregion
