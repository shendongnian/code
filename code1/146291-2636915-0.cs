        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(String lpClassName, String lpWindowName);
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        public static void bringToFront(string title) {
            // Get a handle to the Calculator application.
            IntPtr handle = FindWindow(null, title);
            // Verify that Calculator is a running process.
            if (handle == IntPtr.Zero) {
                return;
            }
            // Make Calculator the foreground application
            SetForegroundWindow(handle);
        }
