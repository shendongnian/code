    using System.Diagnostics;
    using System.Runtime.InteropServices;
    static class Notepad
    {
        #region Imports
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("User32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);
        //this is a constant indicating the window that we want to send a text message
        const int WM_SETTEXT = 0X000C;
        #endregion
        public static void SendText(string text)
        {
            Process notepad = Process.Start(@"notepad.exe");
            System.Threading.Thread.Sleep(50);
            IntPtr notepadTextbox = FindWindowEx(notepad.MainWindowHandle, IntPtr.Zero, "Edit", null);
            SendMessage(notepadTextbox, WM_SETTEXT, 0, text);
        }
    }
