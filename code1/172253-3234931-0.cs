    /// <summary>
    /// Sets an Internet option.
    /// </summary>
    /// <param name="hInternet">Handle on which to set information.</param>
    /// <param name="option">Internet option to be set.</param>
    /// <param name="buffer">Pointer to a buffer that contains the option setting.</param>
    /// <param name="bufferLength">Size of the buffer, in bytes</param>
    /// <returns>Returns TRUE if successful, or FALSE otherwise.</returns>
    /// <see cref="http://msdn.microsoft.com/en-us/library/aa385114(VS.85).aspx"/>
    [DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
    private static extern bool InternetSetOption(
        IntPtr hInternet,
        SET_OPTIONS option,
        IntPtr buffer,
        int bufferLength);
        public enum SET_OPTIONS
        {            
            /// <summary>
            /// Causes the proxy data to be reread from the registry for a handle. No buffer is required. 
            /// </summary>
            INTERNET_OPTION_REFRESH = 37,
            /// <summary>
            /// Notifies the system that the registry settings have been changed so that it verifies the settings on the next call to InternetConnect. 
            /// </summary>
            INTERNET_OPTION_SETTINGS_CHANGED = 39,
            /// <summary>
            /// Sets or retrieves an INTERNET_PER_CONN_OPTION_LIST structure that specifies a list of options for a particular connection.
            /// </summary>
            INTERNET_OPTION_PER_CONNECTION_OPTION = 75
        };
        private static void RefreshInternetExplorerSettings()
        {
            InternetSetOption(IntPtr.Zero, SET_OPTIONS.INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
            InternetSetOption(IntPtr.Zero, SET_OPTIONS.INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);
        }
