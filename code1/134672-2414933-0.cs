    public ControlManager GetControlManager()
    {
        foreach (Control control in Page.Controls)
        {
            if (control is ControlManager)
                return (ControlManager)control;
        }
    
        ControlManager manager = new ControlManager();
        Page.Controls.Add(manager);
        return manager;
    }
