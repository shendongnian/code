    if (this.InvokeRequired)
    {
        Invoke(
            (Action) delegate
                     {
                         statusProgressBar.Value = 0;                 // TOUCH
                         statusLabel.Text = string.Format("{0}%", 0); // TOUCH
                     });
    }
    else
    {
        statusProgressBar.Value = 0;                                 // TOUCH
        statusLabel.Text = string.Format("{0}%", 0);                 // TOUCH
    }
