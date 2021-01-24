    private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
    {
        e.Control.Click += flowLayoutPanel1_ControlClicked;
    }
    private void flowLayoutPanel1_ControlRemoved(object sender, ControlEventArgs e)
    {
        e.Control.Click -= flowLayoutPanel1_ControlClicked;
    }
    private void flowLayoutPanel1_ControlClicked(object sender, EventArgs e)
    {
        var control = (Control)sender;
        label1.Text = control.Text;
    }
    private void flowLayoutPanel2_ControlAdded(object sender, ControlEventArgs e)
    {
        e.Control.Click += flowLayoutPanel2_ControlClicked;
    }
    private void flowLayoutPanel2_ControlRemoved(object sender, ControlEventArgs e)
    {
        e.Control.Click -= flowLayoutPanel2_ControlClicked;
    }
    private void flowLayoutPanel2_ControlClicked(object sender, EventArgs e)
    {
        var control = (Control)sender;
        label2.Text = control.Text;
    }
