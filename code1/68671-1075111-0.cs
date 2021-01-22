    public void AssignMouseMoveEvent(Form form)
    {
        foreach(Control control in form.Controls)
        {
            if(! (control is Panel))
                continue;
            control.MouseMove += PanelMouseMove;
        }
    }
