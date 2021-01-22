    		public static void ShowContextMenu(IntPtr hAppWnd, Window taskBar, System.Windows.Point pt)
		{
			WindowInteropHelper helper = new WindowInteropHelper(taskBar);
			IntPtr callingTaskBarWindow = helper.Handle;
			IntPtr wMenu = GetSystemMenu(hAppWnd, false);
			// Display the menu
			uint command = TrackPopupMenuEx(wMenu,
				TPM.LEFTBUTTON | TPM.RETURNCMD, (int) pt.X, (int) pt.Y, callingTaskBarWindow, IntPtr.Zero);
			if (command == 0)
				return;
	
			PostMessage(hAppWnd, WM.SYSCOMMAND, new IntPtr(command), IntPtr.Zero);
		}
