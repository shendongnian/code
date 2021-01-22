	using System;
	using System.Collections.Generic;
	using Microsoft.Win32;
	using System.Runtime.InteropServices;
	using Microsoft.Win32.SafeHandles;
	public class MyClass
	{
		private const uint GENERIC_ALL = 0x10000000;
		private const uint GENERIC_READ = 0x80000000;
		private const uint GENERIC_WRITE = 0x40000000;
		private const uint GENERIC_EXECUTE = 0x20000000;	
		private const int OPEN_EXISTING = 3;	
		public const int INVALID_HANDLE_VALUE = -1;
		
		public static void Main()
		{
			for (int i = 1; i <= 32; i++)
				Console.WriteLine ("Port {0}: {1}", i, PortExists (i));
		}
		private static bool PortExists (int number) {
			SafeFileHandle h = CreateFile (@"\\.\COM" + number.ToString (), GENERIC_READ + GENERIC_WRITE, 
				0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
			
			bool portExists = !h.IsInvalid;
			
			if (portExists)
				h.Close ();
			
			return portExists;
		}
		
		[DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		private static extern SafeFileHandle CreateFile (string lpFileName, System.UInt32 dwDesiredAccess, 
			System.UInt32 dwShareMode, IntPtr pSecurityAttributes, System.UInt32 dwCreationDisposition, 
			System.UInt32 dwFlagsAndAttributes, IntPtr hTemplateFile);
	}
