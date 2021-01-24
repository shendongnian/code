    int count = 0;
    private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.BackSpace)
            count++;
        else if (e.KeyCode == Keys.Enter)
            //Show Message.
    }
