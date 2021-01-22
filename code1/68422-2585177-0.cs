	public class Utils
	{
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
		private const int WM_VSCROLL = 0x115;
		private const int SB_BOTTOM = 7;
		/// <summary>
		/// Scrolls the vertical scroll bar of a multi-line text box to the bottom.
		/// </summary>
		/// <param name="tb">The text box to scroll</param>
		public static void ScrollToBottom(TextBox tb)
		{
			SendMessage(tb.Handle, WM_VSCROLL, (IntPtr)SB_BOTTOM, IntPtr.Zero);
		}
	}
