    SetHiddenValue(control, "Visible", false);
    SetHiddenValue(control, "Locked", true);
    SetHiddenValue(control, "Enabled", false);
        /// <summary>
        /// Sets the hidden value - these are held in the type descriptor properties.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="name">The name.</param>
        /// <param name="val">The val.</param>
	    private static void SetHiddenValue(Control control, string name, object val)
	    {
	        PropertyDescriptor descriptor = TypeDescriptor.GetProperties(control)[name];
	        if (descriptor != null)
	        {
	            descriptor.SetValue(control, val);
	        }
	    }
