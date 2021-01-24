    foreach(Control x in this.Controls)
    {
        Button btn = x as Button;
        if (btn != null)
        {
            btn.Enabled = true;
        }
    }
