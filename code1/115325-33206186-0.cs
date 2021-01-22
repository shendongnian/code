    internal static class NativeMethods
	{
		// see https://msdn.microsoft.com/en-us/library/windows/desktop/ms684139%28v=vs.85%29.aspx
		public static bool Is64Bit(this Process process)
		{
			if (!Environment.Is64BitOperatingSystem)
				return false;
			bool isWow64;
			if (!IsWow64Process(process.Handle, out isWow64))
				throw new Win32Exception();
			return !isWow64;
		}
		[DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool IsWow64Process([In] IntPtr process, [Out] out bool wow64Process);
	}
