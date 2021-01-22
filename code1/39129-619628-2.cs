    public static IEnumerable<Control> Flatten(this ControlCollection controls)
    {
        List<Control> list = new List<Control>();
        controls.Traverse(c => list.Add(c));
        return list;
    }
    public static IEnumerable<Control> Flatten(this ControlCollection controls,     
        Func<Control, bool> predicate)
    {
        List<Control> list = new List<Control>();
        controls.Traverse(c => { if (predicate(c)) list.Add(c); });
        return list;
    }
    public static void Traverse(this ControlCollection controls, Action<Control> action)
    {
        foreach (Control control in controls)
        {
            action(control);
            if (control.HasControls())
            {
                control.Controls.Traverse(action);
            }
        }
    }
    public static Control GetControl(this Control control, string id)
    {
        return control.Controls.Flatten(c => c.ID == id).SingleOrDefault();
    }
    public static IEnumerable<Control> GetControls(this Control control)
    {
        return control.Controls.Flatten();
    }
