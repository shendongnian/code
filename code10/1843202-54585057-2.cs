    private void richTextBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (!richTextBox1.ClientRectangle.Contains(e.Location))
        {
            richTextBox1.Capture = false;
        }
        else if (!richTextBox1.Capture)
            richTextBox1.Capture = true;
    }
