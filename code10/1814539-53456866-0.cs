    InitializeComponent();
    foreach (Control control in Controls)
    {
        if (control is ButtonBase buttonControl)
        {
            buttonControl.FlatStyle = FlatStyle.System;
        }
    }
