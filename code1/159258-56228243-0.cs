    /// <summary>
    /// Class for flashing a console window
    /// <see cref="https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-flashwinfo"/>
    /// </summary>
    public static class FlashWindow
    {
        /// <summary>
        /// Flashes the specified window. It does not change the active state of the window.
        /// </summary>
        /// <param name="pwfi">FLASHWINFO</param>
        /// <see cref="https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-flashwindowex"/>
        /// <returns>If the window caption was drawn as active before the call, the return value is nonzero. Otherwise, the return value is zero.</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FlashWindowEx(ref FLASHWINFO pwfi);
        /// <summary>
        /// Retrieves the window handle used by the console associated with the calling process.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/windows/console/getconsolewindow"/>
        /// <returns>The return value is a handle to the window used by the console associated with the calling process or NULL if there is no such associated console.</returns>
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
        /// <summary>
        /// Contains the flash status for a window and the number of times the system should flash the window.
        /// <see cref="https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-flashwinfo"/>
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            /// <summary>
            /// The size of the structure, in bytes
            /// </summary>
            public UInt32 cbSize;
            /// <summary>
            /// A handle to the window to be flashed. The window can be either opened or minimized.
            /// </summary>
            public IntPtr hwnd;
            /// <summary>
            /// The flash status. This parameter can be one or more of the following values.
            /// </summary>
            public UInt32 dwFlags;
            /// <summary>
            /// The number of times to flash the window.
            /// </summary>
            public UInt32 uCount;
            /// <summary>
            /// The rate at which the window is to be flashed, in milliseconds. If dwTimeout is zero, the function uses the default cursor blink rate.
            /// </summary>
            public UInt32 dwTimeout;
        }
        /// <summary>
        /// Flash both the window caption and taskbar button. This is equivalent to setting the FLASHW_CAPTION | FLASHW_TRAY flags.
        /// </summary>
        public const UInt32 FLASHW_ALL = 0x00000003;
        /// <summary>
        /// Flash the window caption.
        /// </summary>
        public const UInt32 FLASHW_CAPTION = 0x00000001;
        /// <summary>
        /// Stop flashing. The system restores the window to its original state.
        /// </summary>
        public const UInt32 FLASHW_STOP = 0x00000004;
        /// <summary>
        /// Flash continuously, until the FLASHW_STOP flag is set.
        /// </summary>
        public const UInt32 FLASHW_TIMER = 4;
        /// <summary>
        /// Flash continuously until the window comes to the foreground.
        /// </summary>
        public const UInt32 FLASHW_TIMERNOFG = 0x0000000C;
        /// <summary>
        /// Flash the taskbar button.
        /// </summary>
        public const UInt32 FLASHW_TRAY = 0x00000002;
        /// <summary>
        /// Create an instance of the FLASHWINFO structure
        /// </summary>
        /// <param name="flashwConstant">One of the provided FLASHW contant values</param>
        /// <param name="uCount">uCount to initialize the struct</param>
        /// <param name="dwTimeout">dwTimeout to initalize the struct</param>
        /// <returns>A fully instantiated FLASHWINFO struct</returns>
        private static FLASHWINFO GetFLASHWINFO(UInt32 flashwConstant, UInt32 uCount = UInt32.MaxValue, UInt32 dwTimeout = 0)
        {
            FLASHWINFO fInfo = new FLASHWINFO
            {
                hwnd = GetConsoleWindow(),
                dwFlags = flashwConstant,
                uCount = uCount,
                dwTimeout = dwTimeout
            };
            fInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(fInfo));
            return fInfo;
        }
        /// <summary>
        /// Flashes the console window (continues indefinitely)
        /// </summary>
        public static void Flash()
        {
            FLASHWINFO fInfo = GetFLASHWINFO(FLASHW_ALL);
            FlashWindowEx(ref fInfo);
        }
        /// <summary>
        /// Stops the flashing of the console window
        /// </summary>
        public static void StopFlash()
        {
            FLASHWINFO fInfo = GetFLASHWINFO(FLASHW_STOP);
            FlashWindowEx(ref fInfo);
        }
    }
