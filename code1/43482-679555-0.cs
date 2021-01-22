    ApplyToControlsRecursive(Page, c =>
    {
        var multi = c as System.Web.UI.WebControls.MultiView;
        if (multi != null)
            multi.ActiveViewIndex = 1;
    });
    void ApplyToControlsRecursive(System.Web.UI.Control control, Action<System.Web.UI.Control> action)
    {
        action(control);
        foreach (System.Web.UI.Control child in control.Controls)
        {
            ApplyToControlsRecursive(child, action);
        }
    }
