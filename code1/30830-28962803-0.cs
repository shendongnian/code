    public static void SuspendDrawing(Control control, Action action)
    {
        SendMessage(control.Handle, WM_SETREDRAW, false, 0);
        action();
        SendMessage(control.Handle, WM_SETREDRAW, true, 0);
        control.Refresh();
    }
