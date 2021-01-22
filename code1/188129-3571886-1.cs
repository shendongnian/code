    foreach (Control c in this.Controls)
    {
        if (c is CheckBox)
        {
            ((CheckBox)c).CheckedChanged += c_ControlChanged;
        }
        else
        {
            c.TextChanged += new EventHandler(c_ControlChanged);
        }
    }
