    /// <summary>
    /// suspends drawing on a control and its children
    /// </summary>
    /// <param name="parent"></param>
    public static void SuspendDrawing(Control control)
    {
        SendMessage(control.Handle, WM_SETREDRAW, false, 0);
    }
    /// <summary>
    /// resumes drawing on a control and its children
    /// </summary>
    /// <param name="parent"></param>
    public static void ResumeDrawing(Control control)
    {
        SendMessage(control.Handle, WM_SETREDRAW, true, 0);
        control.Refresh();
    }
