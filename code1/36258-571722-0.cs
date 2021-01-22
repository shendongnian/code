    public static void SafeInvoke(this Control control, Action handler) {
        if (control.InvokeRequired) {
            control.Invoke(handler);
        }
        else {
            handler();
        }
    }
