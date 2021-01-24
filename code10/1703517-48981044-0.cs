    private void CopyButton_Click(object sender, EventArgs e)
    {
        if (richTextBox1.SelectionLength > 0)
            richTextBox1.Copy();
    }
    private void CutButton_Click(object sender, EventArgs e)
    {
        if (richTextBox1.SelectionLength > 0)
            richTextBox1.Cut();
    }
    private void PasteButton_Click(object sender, EventArgs e)
    {
        if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
            richTextBox1.Paste();
    }
