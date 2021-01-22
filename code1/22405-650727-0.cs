    /// <summary>
    /// Window class for handling window stuff.
    /// This is really a hack and taken from Code Project and mutilated to this small thing.
    /// </summary>
    public class Window
    {
        /// <summary>
        /// Win32 API import for getting the process Id.
        /// The out param is the param we are after. I have no idea what the return value is.
        /// </summary>
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out IntPtr ProcessId);
        /// <summary>
        /// Gets a Window's process Id.
        /// </summary>
        /// <param name="hWnd">Handle Id.</param>
        /// <returns>ID of the process.</returns>
        public static IntPtr GetWindowThreadProcessId(IntPtr hWnd)
        {
            IntPtr processId;
            IntPtr returnResult = GetWindowThreadProcessId(hWnd, out processId);
            return processId;
        }
    }
