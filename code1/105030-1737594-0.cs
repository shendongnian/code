        private void ShowScreenSaver(Control displayControl)
        {
            using (RegistryKey desktopKey = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop"))
            {
                if (desktopKey != null)
                {
                    string screenSaverExe = desktopKey.GetValue("SCRNSAVE.EXE") as string;
                    if (!string.IsNullOrEmpty(screenSaverExe))
                    {
                        Process p = Process.Start(screenSaverExe, "/P " + displayControl.Handle);
                        p.WaitForInputIdle();
                        IntPtr hwnd = p.MainWindowHandle;
                        if (hwnd != IntPtr.Zero)
                        {
                            SetParent(hwnd, displayControl.Handle);
                            Rectangle r = displayControl.ClientRectangle;
                            MoveWindow(hwnd, r.Left, r.Top, r.Width, r.Height, true);
                        }
                    }
                }
            }
        }
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hwndChild, IntPtr hwndParent);
        [DllImport("user32.dll")]
        static extern bool MoveWindow(IntPtr hwnd, int x, int y, int width, int height, bool repaint);
