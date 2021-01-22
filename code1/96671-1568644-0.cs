    foreach (Control SubControl in page.Controls)
    {
        if (SubControl is TextBox)
        {
            TextBox ctl = SubControl as TextBox;
        }
    }
