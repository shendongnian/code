    private void textBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == 13)
        {
            if (!textBox.AcceptsReturn)
            {
                button1.PerformClick();
            }
        }
    }
