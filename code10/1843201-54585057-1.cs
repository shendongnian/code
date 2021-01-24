    private void richTextBox1_MouseEnter(object sender, EventArgs e)
    {
        richTextBox1.Capture = true;
    }
    private void richTextBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (!richTextBox1.ClientRectangle.Contains(e.Location))
        {
            richTextBox1.Capture = false;
        }
    }
