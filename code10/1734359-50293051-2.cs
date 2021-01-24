    Font fnt = richTextBox1.Font;
    Color color;
    foreach (Match match in Regex.Matches(richTextBox1.Text, @"\w+"))
    {
        string word = match.Value;
        if (!hunspell.Spell(word))
        {
            fnt = new Font(fnt.FontFamily, fnt.Size, FontStyle.Underline);
            color = Color.Red;
        }
        else
        {
            fnt = new Font(fnt.FontFamily, fnt.Size, FontStyle.Regular);
            color = Color.Black;
        }
        richTextBox1.Select(match.Index, match.Length);        // Selecting the matching word.
        richTextBox1.SelectionFont = fnt;                      // Changing its font and color
        richTextBox1.SelectionColor = color;
        richTextBox1.SelectionStart = richTextBox1.TextLength; // Resetting the selection.
        richTextBox1.SelectionLength = 0;
    }
