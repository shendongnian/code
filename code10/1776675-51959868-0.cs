	static class NativeMethods
	{
		[DllImport("MyLibrary.dll", EntryPoint = "ValidateAdminUser", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
		public static extern Boolean ValidateAdminUser(String username, String password);
	}
