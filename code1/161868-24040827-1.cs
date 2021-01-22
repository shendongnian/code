     class ConsoleWindow
        {
            [DllImport("kernel32.dll", SetLastError = true)]
            static extern bool AllocConsole();
    
            [DllImport("kernel32.dll")]
            static extern bool AttachConsole(int dwProcessId);
            private const int ATTACH_PARENT_PROCESS = -1;
    
            [DllImport("kernel32.dll")]
            static extern IntPtr GetConsoleWindow();
    
            [DllImport("user32.dll")]
            static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    
            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            static extern bool SetWindowText(IntPtr hwnd, String lpString);
    
            [DllImport("user32.dll")]
            static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
    
            [DllImport("user32.dll")]
            static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);
    
            [DllImport("kernel32.dll", SetLastError = true)]
            static extern bool SetConsoleIcon(IntPtr hIcon);
    
            const int SW_HIDE = 0;
            const int SW_SHOW = 5;
    
            const int SC_CLOSE = 0xF060;
            const int MF_GRAYED = 1;
    
            public static void AttachConsoleWindow()
            {
                // redirect console output to parent process;
                // must be before any calls to Console.WriteLine()
                AttachConsole(ATTACH_PARENT_PROCESS);
            }
    
            public static void ShowConsoleWindow()
            {
                var handle = GetConsoleWindow();
    
                if (handle == IntPtr.Zero)
                {
                    AllocConsole();
                }
                else
                {
                    ShowWindow(handle, SW_SHOW);
                }
            }
    
            public static void HideConsoleWindow()
            {
                var handle = GetConsoleWindow();
    
                ShowWindow(handle, SW_HIDE);
            }
    
            public static void SetWindowText(string text)
            {
                var handle = GetConsoleWindow();
    
                SetWindowText(handle, text);
            }
    
            public static void DisableCloseButton()
            {
                var handle = GetConsoleWindow();
    
                var hmenu = GetSystemMenu(handle, false);
    
                EnableMenuItem(hmenu, SC_CLOSE, MF_GRAYED);
            }
    
            public static void SetConsoleIcon(System.Drawing.Icon icon)
            {
                SetConsoleIcon(icon.Handle);
            }
        }
