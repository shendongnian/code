    Control FindControl(Control root, string controlName)
    {
        foreach (Control c in root.Controls)
        {
            if (c.Controls.Count > 0)
                return FindControl(c);
            else if (c.Name == controlName)
                return c;            
        }
        return null;
    }
