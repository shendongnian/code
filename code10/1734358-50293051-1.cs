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
        richTextBox1.Select(match.Index, match.Length);
        richTextBox1.SelectionFont = fnt;
        richTextBox1.SelectionColor = color;
    }
