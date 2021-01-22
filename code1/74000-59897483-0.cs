    class IconChanger
    {
        public static void SetConsoleIcon(string iconFilePath)
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                if (!string.IsNullOrEmpty(iconFilePath))
                {
                    System.Drawing.Icon icon = new System.Drawing.Icon(iconFilePath);
                    SetWindowIcon(icon);
                }
            }
        }
        public enum WinMessages : uint
        {
            /// <summary>
            /// An application sends the WM_SETICON message to associate a new large or small icon with a window. 
            /// The system displays the large icon in the ALT+TAB dialog box, and the small icon in the window caption. 
            /// </summary>
            SETICON = 0x0080,
        }
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);
        private static void SetWindowIcon(System.Drawing.Icon icon)
        {
            IntPtr mwHandle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            IntPtr result01 = SendMessage(mwHandle, (int)WinMessages.SETICON, 0, icon.Handle);
            IntPtr result02 = SendMessage(mwHandle, (int)WinMessages.SETICON, 1, icon.Handle);
        }// SetWindowIcon()
    }
