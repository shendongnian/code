    private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
    {
        RichTextBox box = (RichTextBox)sender;
        if (e.Button == MouseButtons.Right)
        {
            box.SelectionStart = box.GetCharIndexFromPosition(e.Location);
            box.SelectionLength = 0;
        }
    }
