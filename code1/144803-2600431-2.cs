    bool FocusFirst(ControlCollection controls)
    {
        foreach (Control c in controls)
        {
            if (c.Visible)
            {
                c.Focus();
                FocusFirst(c.Controls);
                break;
            }
        }
    }
