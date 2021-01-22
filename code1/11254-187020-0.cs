    public static Control FindControlRecursive(Control rootControl, string id)
    {
        if (rootControl != null)
        {
            if (rootControl.ID == id)
            {
                return rootControl;
            }
            for (int i = 0; i < rootControl.Controls.Count; i++)
            {
                Control child;
                if ((child = FindControlRecursive(rootControl.Controls[i], id)) != null)
                {
                    return child;
                }
            }
        }
        return null;
    }
