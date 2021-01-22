    public static Control FindControl(Form form, string name)
    {
        foreach (Control control in form.Controls)
        {
            Control result = FindControl(form, control, name);
            if (result != null)
                return result;
        }
        return null;
    }
    private static Control FindControl(Form form, Control control, string name)
    {
        if (control.Name == name) {
            return control;
        }
        foreach (Control subControl in control.Controls)
        {
            Control result = FindControl(form, subControl, name);
            if (result != null)
                return result;
        }
        return null;
    }
