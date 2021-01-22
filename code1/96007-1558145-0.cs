    public static void SetEnabled(Control control, bool enabled) {
        control.Enabled = enabled;
        foreach(Control child in control.Controls) {
            SetEnabled(child, enabled);
        }
    }
