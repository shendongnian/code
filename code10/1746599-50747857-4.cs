    bool found = false;
    foreach (Control c in this.Controls)
    {
        if (c is Label && c.Text.Contains("abc"))
        {
            found = true;
            break;
        }
    }
    button1.Enabled = !found;
