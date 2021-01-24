    bool found = false;
    foreach (Control c in this.Controls)
    {
        if (c is Label && (c as Label).Text.Contains("abc"))
        {
            found = true;
            break;
        }
    }
    button1.Enabled = !found;
