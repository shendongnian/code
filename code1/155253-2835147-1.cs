    public void FindNext(string searchText)
    {
        try
        {
            this.Focus();
            richTextBox1.Focus();
            findPos = richTextBox1.Find(searchText, findPos, RichTextBoxFinds.None);
            richTextBox1.Select(findPos + 1, searchText.Length);
            findPos += searchText.Length;
        }
        catch
        {
            MessageBox.Show("No Occurences Found");
            findPos = 0;
        }
    }
