        [DllImport("USER32.DLL")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);
        [DllImport("user32.dll")]
        static extern IntPtr GetMenu(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern int GetMenuItemCount(IntPtr hMenu);
        [DllImport("user32.dll")]
        static extern bool DrawMenuBar(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern bool RemoveMenu(IntPtr hMenu, uint uPosition, uint uFlags);
        public static uint MF_BYPOSITION = 0x400;
        public static uint MF_REMOVE = 0x1000;
        public static void WindowsReStyle() {
            Process[] Procs = Process.GetProcesses();
            foreach (Process proc in Procs) {
                if (proc.ProcessName.StartsWith("notepad")) {
                    //get menu
                    IntPtr HMENU = GetMenu(proc.MainWindowHandle);
                    //get item count
                    int count = GetMenuItemCount(HMENU);
                    //loop & remove
                    for (int i = 0; i < count; i++)
                        RemoveMenu(HMENU, 0, (MF_BYPOSITION | MF_REMOVE));
                    //force a redraw
                    DrawMenuBar(proc.MainWindowHandle);
                }
            }
        }
