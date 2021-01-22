    /// <summary>
    /// The WM_SIZING message is sent to a window that
    /// the user is resizing.  By processing this message,
    /// an application can monitor the size and position
    /// of the drag rectangle and, if needed, change its
    /// size or position. 
    /// </summary>
    const int WM_SIZING = 0x0214;
    
    /// <summary>
    /// The WM_SIZE message is sent to a window after its
    /// size has changed.
    /// </summary>
    const int WM_SIZE = 0x0005;
