    foreach (Control c in this.Controls)
    {
        if (c is TextBox && c.Name.StartsWith("sum"))
        {
            sumTextboxNames[y] = (TextBox)c;
            y++;
        }
    }
