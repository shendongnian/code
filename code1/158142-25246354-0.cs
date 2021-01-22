    private static Control FindFocusedControl(Control container)
    {
    	foreach (Control childControl in container.Controls.Cast<Control>().Where(childControl => childControl.Focused)) return childControl;
    	return (from Control childControl in container.Controls select FindFocusedControl(childControl)).FirstOrDefault(maybeFocusedControl => maybeFocusedControl != null);
    }
