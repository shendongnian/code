	using System;
	using System.Collections;
	using System.Runtime.InteropServices;
	using System.Text;
	namespace WinAPI
	{
		[Flags] public enum WindowStyleFlags : uint
		{
			WS_OVERLAPPED      = 0x00000000,
			WS_POPUP           = 0x80000000,
			// more...
		}
	    
		[Flags] public enum ExtendedWindowStyleFlags: int
		{
			WS_EX_DLGMODALFRAME    = 0x00000001,
			WS_EX_NOPARENTNOTIFY   = 0x00000004,
			// more...
		}
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct RECT
		{
			public int Left;
			public int Top;
			public int Right;
			public int Bottom;
		}
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct POINT
		{
			public int Left;
			public int Top;
		}
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct FLASHWINFO
		{
			public int cbSize;
			public IntPtr hwnd;
			public int dwFlags;
			public int uCount;
			public int dwTimeout;
		}
		public delegate int EnumWindowsCallback( IntPtr hwnd, int lParam );
		public class User32Dll
		{
			// Constants & fields
			public const int FLASHW_STOP = 0;
			public const int FLASHW_CAPTION = 0x00000001;
			// lots, lots more, web search for them...
			// Self-added, don't know if correct
			[DllImport("user32")]
			public extern static bool CloseWindow( IntPtr hWnd );
			[DllImport("user32")]
			public extern static IntPtr GetDesktopWindow();
			[DllImport("user32")]
			public extern static IntPtr GetForegroundWindow();
			[DllImport("user32")]
			public extern static int GetDlgItem( IntPtr hWnd, int wMsg );
			[DllImport("user32")]
			public extern static int GetListBoxInfo( IntPtr hWnd );
			[DllImport("user32")]
			public extern static bool MoveWindow( IntPtr hWnd, int X, int Y, int Width, int Height, bool Repaint );
			[DllImport( "user32" )]
			public static extern int SendMessage( IntPtr hWnd, int uMsg, IntPtr wParam, StringBuilder lpString );
			[DllImport("user32")]
			public static extern bool SetWindowPos( IntPtr hWnd, IntPtr afterWnd, int X, int Y, int cX, int cY, uint uFlags );
			[DllImport("user32")]
			public extern static int BringWindowToTop (IntPtr hWnd);
			[DllImport("user32")]
			public extern static int EnumWindows( EnumWindowsCallback lpEnumFunc, int lParam );
			[DllImport("user32")]
			public extern static int EnumChildWindows( IntPtr hWndParent, EnumWindowsCallback lpEnumFunc, int lParam );
			[DllImport( "user32.dll" )]
			public static extern int EnumThreadWindows( IntPtr hWndParent, EnumWindowsCallback callback, int lParam );
			[DllImport( "user32.dll" )]
			public static extern int FindWindow( string lpClassName, string WindowName );
			[DllImport( "user32.dll" )]
			public static extern int FindWindowEx( IntPtr hWnd, IntPtr hWnd2, string lpsz, string lpsz2 );
			[DllImport("user32")]
			public extern static int FlashWindow ( IntPtr hWnd, ref FLASHWINFO pwfi);
			[DllImport("user32")]
			public extern static IntPtr GetAncestor( IntPtr hWnd, uint gaFlags );
			[DllImport("user32", CharSet = CharSet.Auto)]
			public extern static int GetClassName ( IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
			[DllImport("user32", CharSet = CharSet.Auto)]
			public extern static uint GetWindowLong( IntPtr hwnd, int nIndex);
			[DllImport("user32")]
			public extern static int GetClientRect( IntPtr hWnd, ref RECT lpRect);
			[DllImport("user32")]
			public extern static int GetWindowRect( IntPtr hWnd, ref RECT lpRect);
			[DllImport("user32", CharSet = CharSet.Auto)]
			public extern static int GetWindowText( IntPtr hWnd, StringBuilder lpString, int cch );
			[DllImport("user32", CharSet = CharSet.Auto)]
			public extern static int GetWindowTextLength( IntPtr hWnd );
			[DllImport("user32")]
			public extern static int IsIconic(IntPtr hWnd);
			[DllImport("user32")]
			public extern static int IsWindowVisible( IntPtr hWnd );
			[DllImport("user32")]
			public extern static int IsZoomed(IntPtr hwnd);
			[DllImport("user32", CharSet = CharSet.Auto)]
			public extern static int PostMessage( IntPtr hWnd, int wMsg, int wParam, int lParam);
			[DllImport( "user32.dll" )]
			public static extern int RealGetWindowClass( IntPtr hWnd, StringBuilder pszType, uint bufferSize );
			[DllImport("user32")]
			public extern static int ScreenToClient( IntPtr hWnd, ref POINT lpPoint);
			[DllImport("user32", CharSet = CharSet.Auto)]
			public extern static int SendMessage( IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
			[DllImport("user32.dll")]
			public extern static int SetForegroundWindow (IntPtr hWnd);
			[DllImport( "user32.dll" )]
			public static extern int SetWindowText( IntPtr hWnd, string lpsz );
		}
	}
