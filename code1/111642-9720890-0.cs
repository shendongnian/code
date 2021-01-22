	public class FullScreenEngine
	{
		// Fields
		private IntPtr _hWndInputPanel;
		private IntPtr _hWndSipButton;
		private IntPtr _hWndTaskBar;
		private Rectangle _desktopArea;
		public FullScreenEngine()
		{
			Init();
		}
		public bool SetFullScreen(bool mode)
		{
			try
			{
				if (mode)
				{
					if (_hWndTaskBar.ToInt64() != 0L)
					{
						ShowWindow(_hWndTaskBar, SW_HIDE);
					}
					if (_hWndInputPanel.ToInt64() != 0L)
					{
						ShowWindow(_hWndInputPanel, SW_HIDE);
					}
					if (_hWndSipButton.ToInt64() != 0L)
					{
						ShowWindow(_hWndSipButton, SW_HIDE);
					}
					WorkArea.SetWorkArea(new RECT(Screen.PrimaryScreen.Bounds));
				}
				else
				{
					if (_hWndTaskBar.ToInt64() != 0L)
					{
						ShowWindow(_hWndTaskBar, SW_SHOW);
					}
					if (_hWndInputPanel.ToInt64() != 0L)
					{
						//ShowWindow(_hWndInputPanel, SW_SHOW);
					}
					if (_hWndSipButton.ToInt64() != 0L)
					{
						ShowWindow(_hWndSipButton, SW_SHOW);
					}
					WorkArea.SetWorkArea(new RECT(_desktopArea));
				}
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}
		private bool Init()
		{
			try
			{
				_desktopArea = Screen.PrimaryScreen.WorkingArea;
				_hWndInputPanel = FindWindowW("SipWndClass", null);
				_hWndSipButton = FindWindowW("MS_SIPBUTTON", null);
				_hWndTaskBar = FindWindowW("HHTaskBar", null);
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}
		private const uint SW_HIDE = 0;
		private const uint SW_SHOW = 1;
		[DllImport("coredll.dll")]
		private static extern int ShowWindow(IntPtr hwnd, uint command);
		[DllImport("coredll.dll")]
		private static extern IntPtr FindWindowW(string lpClassName, string lpWindowName);
		// Nested Types
		public struct RECT
		{
			public int Left;
			public int Top;
			public int Right;
			public int Bottom;
			public RECT(Rectangle rect) : this()
			{
				Left = rect.Left;
				Right = rect.Left+rect.Width;
				Top = rect.Top;
				Bottom = rect.Top + rect.Height;
			}
		}
		private static class WorkArea
		{
			[DllImport("coredll.dll")]
			private static extern bool SystemParametersInfo(uint uAction, uint uparam, ref RECT rect, uint fuWinIni);
			private const uint WM_SETTINGCHANGE = 0x1a;
			const uint SPI_GETWORKAREA = 48;
			const uint SPI_SETWORKAREA = 47;
			public static bool SetWorkArea(RECT rect)
			{
				return SystemParametersInfo(SPI_SETWORKAREA, 0, ref rect, WM_SETTINGCHANGE);
			}
			public static RECT GetWorkArea()
			{
				var rect = new RECT();
				SystemParametersInfo(SPI_GETWORKAREA, 0, ref rect, 0);
				return rect;
			}
		}
	}
