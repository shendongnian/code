    foreach(Control ctrl in this.Controls)
    {
        if(ctrl is Button)
        {
            (ctrl as Button).Click += // generic Event handler
        }
    }
