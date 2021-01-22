    private Control FindControlRecursive(Control control, string id)
    {
        Control returnControl = control.FindControl(id);
        if (returnControl == null)
        {
            foreach (Control child in control.Controls)
            {
                returnControl = child.FindControlRecursive(id);
                if (returnControl != null && returnControl.ID == id)
                {
                    return returnControl;
                }
            }
        }
        return returnControl;
    }
