    private void txtItemName_KeyUp(object sender, KeyEventArgs e)
    {
        // track for backspace
        if (e.KeyCode == Keys.Back)
        {
            if (txtItemName.Text != "")
            {
                string text = txtItemName.Text.Substring(0, txtItemName.Text.Count() - 1);
                txtItemName.Text = "";
                txtItemName.Focus();
                SendKeys.Send(text);
            }
        }
    }
