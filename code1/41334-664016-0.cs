    public static List<Control> GetControls(Control form)
    {
        var controlList = new List<Control>();
        foreach (Control childControl in form.Controls)
        {
            // Recurse child controls.
            controlList.AddRange(GetControls(childControl));
            controlList.Add(childControl);
        }
        return controlList;
    }
