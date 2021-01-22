    public void GetUserControls(ControlCollection controls)
    {
        foreach (Control ctl in controls)
        {
            if (ctl is UserControl)
            {
                // Do whatever.
            }
            if (ctl.Controls.Count > 0)
                GetUserControls(ctl.Controls);
        }
    }
