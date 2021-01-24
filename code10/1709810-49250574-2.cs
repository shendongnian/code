    private void TextBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            button1.PerformClick();
            e.Handled = true;
            e.SuppressKeyPress = true;
        }
    }
