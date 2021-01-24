    foreach (Control c in this.Controls)
    {
        if (c is Button || c is Label)
        {
            // Do something here
            c.Tag = "I'm a button or a label";
        }
    }
