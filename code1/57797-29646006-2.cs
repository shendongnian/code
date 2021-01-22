    public class Utils
    {
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern int SendMessage(System.IntPtr hWnd, int wMsg, System.IntPtr wParam, System.IntPtr lParam);
        private const int WM_VSCROLL = 0x115;
        private const int SB_BOTTOM = 7;
        /// <summary>
        /// Scrolls the vertical scroll bar of a multi-line text box to the bottom.
        /// </summary>
        /// <param name="tb">The text box to scroll</param>
        public static void ScrollToBottom(System.Windows.Forms.TextBox tb)
        {
            if(System.Environment.OSVersion.Platform != System.PlatformID.Unix)
                 SendMessage(tb.Handle, WM_VSCROLL, new System.IntPtr(SB_BOTTOM), System.IntPtr.Zero);
        }
    }
