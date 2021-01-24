    // Flag variable that allows KeyDown to communicate with KeyPress
    private bool cancelKeyPress = false;
    private void richTextBox2_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            richTextBox1.Text += $"Plan1:   {richTextBox2.Text}\n";
            richTextBox2.Text = "";
            // Set our flag so KeyPress knows we should ignore this key stroke
            cancelKeyPress = true;
        }
    }
    private void richTextBox2_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (cancelKeyPress)
        {
            e.Handled = true;
            richTextBox2.SelectionStart = 0;
            // Set our flag back to false again
            cancelKeyPress = false;
        }
    }
