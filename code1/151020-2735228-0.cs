    public static Control GetControl(Control.ControlCollection controlCollection, Predicate<Control> match)
    {
        foreach (Control control in controlCollection)
        {
            if (match(control))
            {
                return control;
            }
    
            if (control.Controls.Count > 0)
            {
                Control result = GetControl(control.Controls, match);
                if (result != null)
                {
                    return result;
                }
            }
        }
    
        return null;
    }
