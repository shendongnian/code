    public System.Windows.Forms.Control FindFocusedControl()
    {
        return FindFocusedControl(this);
    }
    
    public static System.Windows.Forms.Control FindFocusedControl(System.Windows.Forms.Control container)
    {
        foreach (System.Windows.Forms.Control childControl in container.Controls)
        {
            if (childControl.Focused)
            {
                return childControl;
            }
        }
    
        foreach (System.Windows.Forms.Control childControl in container.Controls)
        {
            System.Windows.Forms.Control maybeFocusedControl = FindFocusedControl(childControl);
            if (maybeFocusedControl != null)
            {
                return maybeFocusedControl;
            }
        }
    
        return null; // Couldn't find any, darn!
    }
