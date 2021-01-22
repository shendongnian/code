    public static void ApplyAll(Control control, Action<Control> action) {
        action(control);
        foreach(Control child in control.Controls) {
            ApplyAll(child, action);
        }
    }
