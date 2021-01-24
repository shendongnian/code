    private void searchTextBox_TextChanged(object sender, EventArgs e)
    {
        Regex regex = new Regex(searchTextBox.Text);
        MatchCollection matches = regex.Matches(richTextArea.Text);
        richTextArea.SelectAll();
        richTextArea.SelectionBackColor = richTextArea.BackColor;
        foreach (Match match in matches)
        {
            richTextArea.Select(match.Index, match.Length);
            richTextArea.SelectionBackColor = Color.Yellow;
        }
    }
