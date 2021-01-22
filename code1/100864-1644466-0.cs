    DisableControls(Control c)
    {
        c.Enable  = false;
        foreach(Control child in c.Controls)
           DisableControls(child)
    }
