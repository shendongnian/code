        class NativeMethods
		{
			[System.Runtime.InteropServices.DllImport("user32.dll")]
			[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
			static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);
			/// <summary>
			/// See MSDN RECT Structure http://msdn.microsoft.com/en-us/library/dd162897(v=VS.85).aspx
			/// </summary>
			private struct RECT
			{
				public int left;
				public int top;
				public int right;
				public int bottom;
			} 
			/// <summary>
			/// See MSDN WINDOWPLACEMENT Structure http://msdn.microsoft.com/en-us/library/ms632611(v=VS.85).aspx
			/// </summary>
			private struct WINDOWPLACEMENT
			{
				public int length;
				public int flags;
				public int showCmd;
				public Point ptMinPosition;
				public Point ptMaxPosition;
				public RECT rcNormalPosition;
			}
			/// <summary>
			/// Gets the window placement of the specified window in Normal state.
			/// </summary>
			/// <param name="handle">The handle.</param>
			/// <returns></returns>
			public static Rectangle GetPlacement(IntPtr handle)
			{
				WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
				placement.length = System.Runtime.InteropServices.Marshal.SizeOf(placement);
				GetWindowPlacement(handle, ref placement);
				var rect = placement.rcNormalPosition;
				return new Rectangle(rect.left, rect.top, rect.right - rect.left, rect.bottom - rect.top);
			}
		}
