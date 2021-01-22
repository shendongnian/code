I ran into exactly the same problem.  Here's a program that's working for me.  It uses EnumWindows to search through all *visible* windows until it finds one whose title is a real path.
	using System;
	using System.IO;
	using System.Text;
	using System.Diagnostics;
	using System.Runtime.InteropServices;
	public class ShellHere
	{
		// Thanks to pinvoke.net for the WinAPI stuff
		
		[DllImport("user32.dll")]
		private static extern int EnumWindows(CallBackPtr callPtr, int lPar); 
		[DllImport("user32.dll")]
		static extern int GetWindowText(int hWnd, StringBuilder text, int count);
		[DllImport("user32.dll", EntryPoint="GetWindowLong")]
		private static extern IntPtr GetWindowLongPtr32(IntPtr hWnd, GWL nIndex);
		[DllImport("user32.dll", EntryPoint="GetWindowLongPtr")]
		private static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, GWL nIndex);
		public delegate bool CallBackPtr(int hwnd, int lParam);
		private static CallBackPtr _callBackPtr;
		
		// This static method is required because Win32 does not support
		// GetWindowLongPtr directly
		public static IntPtr GetWindowLongPtr(IntPtr hWnd, GWL nIndex)
		{
			if (IntPtr.Size == 8)
				return GetWindowLongPtr64(hWnd, nIndex);
			else
				return GetWindowLongPtr32(hWnd, nIndex);
		}
		
		public static bool FindPathInTitle( int hwnd, int lparams )
		{
			const int nChars = 256;
			StringBuilder buffer = new StringBuilder( nChars );
			
			IntPtr result = GetWindowLongPtr( new IntPtr(hwnd), GWL.GWL_STYLE );
			
			// ignore invisible windows
			if ( (result.ToInt64() & WS_VISIBLE) != 0 )
			{
				if ( GetWindowText( hwnd, buffer, nChars ) > 0 )
				{
					string title = buffer.ToString();
					
					// ignore the taskbar
					if ( title.ToLower() != "start" && Directory.Exists( title ) )
					{
						_folder = title;
						return false;
					}
				}
			}
				
			return true;
		}
		
		private static string _folder;
		public static void Main()
		{
			_callBackPtr = new CallBackPtr( FindPathInTitle );
			EnumWindows( _callBackPtr, 0 );
			
			Process shell = new Process();
			shell.StartInfo.FileName = "cmd.exe";
			if ( !string.IsNullOrEmpty( _folder ) )
				shell.StartInfo.WorkingDirectory = _folder;
			shell.Start();
		}
		
		public enum GWL
		{
			GWL_WNDPROC =    (-4),
			GWL_HINSTANCE =  (-6),
			GWL_HWNDPARENT = (-8),
			GWL_STYLE =      (-16),
			GWL_EXSTYLE =    (-20),
			GWL_USERDATA =   (-21),
			GWL_ID =     (-12)
		}
		
		// Window Styles 
		const UInt32 WS_VISIBLE = 0x10000000;
	}
