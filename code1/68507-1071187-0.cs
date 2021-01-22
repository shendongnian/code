    public void FindContextMenuStrip(Control input)
    {
        foreach(Control control in input.Controls)
        {
            if(control.ContextMenuStrip != null)
                DoSomethingWithContextMenuStrip(control.ContextMenuStrip)
            
            if(control.Controls.Count > 0)
                FindContextMenuStrip(control);
        }
    }
