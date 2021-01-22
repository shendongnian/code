    // Copyright (C) 2005-2015 Alexander Batishchev (abatishchev at gmail.com)
    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    namespace Reg2Run
    {
    	static class ManualConsole
    	{
    		#region DllImport
    		/*
    		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    		[return: MarshalAs(UnmanagedType.Bool)]
    		private static extern bool AllocConsole();
    		*/
    		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    		[return: MarshalAs(UnmanagedType.Bool)]
    		private static extern bool CloseHandle(IntPtr handle);
    		/*
    		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    		private static extern IntPtr CreateFile([MarshalAs(UnmanagedType.LPStr)]string fileName, [MarshalAs(UnmanagedType.I4)]int desiredAccess, [MarshalAs(UnmanagedType.I4)]int shareMode, IntPtr securityAttributes, [MarshalAs(UnmanagedType.I4)]int creationDisposition, [MarshalAs(UnmanagedType.I4)]int flagsAndAttributes, IntPtr templateFile);
    		*/
    		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    		[return: MarshalAs(UnmanagedType.Bool)]
    		private static extern bool FreeConsole();
    		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    		private static extern IntPtr GetStdHandle([MarshalAs(UnmanagedType.I4)]int nStdHandle);
    		/*
    		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    		[return: MarshalAs(UnmanagedType.Bool)]
    		private static extern bool SetStdHandle(int nStdHandle, IntPtr handle);
    		*/
    		#endregion
    		#region Methods
    		/*
    		public static void Create()
    		{
    			var ptr = GetStdHandle(-11);
    			if (!AllocConsole())
    			{
    				throw new Win32Exception("AllocConsole");
    			}
    			ptr = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, 3, 0, IntPtr.Zero);
    			if (!SetStdHandle(-11, ptr))
    			{
    				throw new Win32Exception("SetStdHandle");
    			}
    			var newOut = new StreamWriter(Console.OpenStandardOutput());
    			newOut.AutoFlush = true;
    			Console.SetOut(newOut);
    			Console.SetError(newOut);
    		}
    		*/
    		public static void Hide()
    		{
    			var ptr = GetStdHandle(-11);
    			if (!CloseHandle(ptr))
    			{
    				throw new Win32Exception();
    			}
    			ptr = IntPtr.Zero;
    			if (!FreeConsole())
    			{
    				throw new Win32Exception();
    			}
    		}
    		#endregion
    	}
    }
