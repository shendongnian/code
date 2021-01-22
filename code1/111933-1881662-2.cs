    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    private const int WM_PRINT = 791;
    /// <summary>
    /// The WM_PRINT drawing options
    /// </summary>
    [Flags]
    private enum DrawingOptions
    {
        /// <summary>
        /// Draws the window only if it is visible.
        /// </summary>
        PRF_CHECKVISIBLE = 1,
        /// <summary>
        /// Draws the nonclient area of the window.
        /// </summary>
        PRF_NONCLIENT = 2,
        /// <summary>
        /// Draws the client area of the window.
        /// </summary>
        PRF_CLIENT = 4,
        /// <summary>
        /// Erases the background before drawing the window.
        /// </summary>
        PRF_ERASEBKGND = 8,
        /// <summary>
        /// Draws all visible children windows.
        /// </summary>
        PRF_CHILDREN = 16,
        /// <summary>
        /// Draws all owned windows.
        /// </summary>
        PRF_OWNED = 32
    }
