	private static string GetProcessUser(Process process)
	{
		IntPtr processHandle = IntPtr.Zero;
		try
		{
			OpenProcessToken(process.Handle, 8, out processHandle);
			WindowsIdentity wi = new WindowsIdentity(processHandle);
			string user = wi.Name;
			return user.Contains(@"\") ? user.Substring(user.IndexOf(@"\") + 1) : user;
		}
		catch
		{
			return null;
		}
		finally
		{
			if (processHandle != IntPtr.Zero)
			{
				CloseHandle(processHandle);
			}
		}
	}
	[DllImport("advapi32.dll", SetLastError = true)]
	private static extern bool OpenProcessToken(IntPtr ProcessHandle, uint DesiredAccess, out IntPtr TokenHandle);
	[DllImport("kernel32.dll", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool CloseHandle(IntPtr hObject);
