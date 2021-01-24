    foreach (Control c in Controls)
    {
        if (c.GetType() == typeof(Panel))
        {
            // Invert the visibility state of the panel
            c.Visible = !c.Visible;
        }
    }
