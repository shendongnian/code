    private void DisableControls(System.Web.UI.Control control)
    {
        foreach (System.Web.UI.Control c in control.Controls) 
        {
            // Get the Enabled property by reflection.
            Type type = c.GetType();
            PropertyInfo prop = type.GetProperty("Enabled");
            // Set it to False to disable the control.
            if (prop != null) 
            {
                prop.SetValue(c, false, null);
            }
            // Recurse into child controls.
            if (c.Controls.Count > 0) 
            {
                this.DisableControls(c);
            }
        }
    }
