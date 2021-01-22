using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
class Program
{
	[DllImport("coredll", SetLastError = true)]
	public static extern uint GetModuleFileName(IntPtr hModule, StringBuilder lpFilename, [MarshalAs(UnmanagedType.U4)] int nSize);
	[DllImport("coredll")]
	public static extern uint FormatMessage([MarshalAs(UnmanagedType.U4)] FormatMessageFlags dwFlags, IntPtr lpSource, uint dwMessageId, uint dwLanguageId, out IntPtr lpBuffer, uint nSize, IntPtr Arguments);
	[DllImport("coredll")]
	public static extern IntPtr LocalFree(IntPtr hMem);
	[Flags]
	internal enum FormatMessageFlags : uint
	{
		AllocateBuffer = 256,
		FromSystem = 4096,
		IgnoreInserts = 512
	}
	public static string GetModuleFileName(IntPtr hModule)
	{
		StringBuilder lpFilename = new StringBuilder(short.MaxValue);
		uint num = GetModuleFileName(hModule, lpFilename, lpFilename.Capacity);
		if (num == 0)
		{
			throw CreateWin32Exception(Marshal.GetLastWin32Error());
		}
		return lpFilename.ToString();
	}
	private static Win32Exception CreateWin32Exception(int error)
	{
		IntPtr buffer = IntPtr.Zero;
		try
		{
			if (FormatMessage(FormatMessageFlags.IgnoreInserts | FormatMessageFlags.FromSystem | FormatMessageFlags.AllocateBuffer, IntPtr.Zero, (uint)error, 0, out buffer, 0, IntPtr.Zero) == 0)
			{
				return new Win32Exception();
			}
			return new Win32Exception(error, Marshal.PtrToStringUni(buffer));
		}
		finally
		{
			if (buffer != IntPtr.Zero)
			{
				LocalFree(buffer);
			}
		}
	}
	public static string GetStartupPath()
	{
		return Path.GetDirectoryName(GetExecutablePath());
	}
	public static string GetExecutablePath()
	{
		return GetModuleFileName(IntPtr.Zero);
	}
}
  
