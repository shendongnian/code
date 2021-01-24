    // Case A
    public static Control AddAndReturn(this ControlCollection controls, Control control)
    {
        controls.Add(control);
        return control;
    }
    // Case B
    public static Control Add(this ControlCollection controls, Control control, bool returnControl)
    {
        controls.Add(control);
        if (returnControl)
            return control;
        return null;
    }
