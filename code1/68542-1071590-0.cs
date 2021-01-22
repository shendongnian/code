    foreach (Control control in Controls)
    {
        // I am assuming MyUserControl_Click handles the click event of the user control.
        control.Click += MyUserControl_Click;
    }
