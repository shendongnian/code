    public static IEnumerable<Control> AllControls(
        this Control control, 
        Func<Control, Boolean> filter = null) 
    {
        if (control == null)
            throw new ArgumentNullException("control");
        if (filter == null)
            filter = (c => true);
        var list = new List<Control>();
        foreach (Control c in control.Controls) {
            list.AddRange(AllControls(c, filter));
            if (filter(c))
                list.Add(c);
        }
        return list;
    }
