    using System;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Interop;
    using System.Windows.Threading;
    
    namespace HQ.Util.Unmanaged
    {
    	public class WindowHelper
    	{
    		[DllImport("user32.dll")]
    		[return: MarshalAs(UnmanagedType.Bool)]
    		public static extern bool SetForegroundWindow(IntPtr hWnd);
