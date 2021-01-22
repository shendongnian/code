    foreach (Control c in Controls)
    {
        if (c.Visible)
        {
            c.Focus();
            break;
        }
    }
