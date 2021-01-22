    private void Form_OnLoad(object obj, EventArgs e)
    {
        AddGotFocusListener(this);
    }
    private void AddGotFocusListener(Control ctrl)
    {
        foreach(Control c in ctrl.Controls)
        {
            c.GotFocus += new EventHandler(Control_GotFocus);
            if(c.Controls.Count > 0)
            {
                AddGotFocusListener(c);
            }
        }
    }
    private void Control_GotFocus(object obj, EventArgs e)
    {
        // Set focused control here
    }
