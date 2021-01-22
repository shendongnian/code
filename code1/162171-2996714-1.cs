    private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            RichTextBox box = (RichTextBox)sender;
            box.SelectionStart = box.GetCharIndexFromPosition(e.Location);
            box.SelectionLength = 0;
        }
    }
