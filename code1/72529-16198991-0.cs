    private void HandleTextKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.A)
        {
            ((TextBox)sender).SelectAll();
            e.Handled = true;
        }
    }
