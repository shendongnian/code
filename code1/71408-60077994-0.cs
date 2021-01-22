    if (e.KeyData == (Keys.Back | Keys.Control))
    {
	e.SuppressKeyPress = true;
	string text="";
	foreach (string s in separators)
	{
		// (\))?\W*$ not word
		// (\w)?\w*$ word
		Match m = Regex.Match(Text, $@"(\{s})?\W*$");
		if (!m.Value.Equals(""))
		{
			text = Regex.Replace(Text.Substring(0, SelectionStart), $@"(\{s})?\W?$", "");
			break;
		}
	}
	if (text.Equals(""))
		text = Regex.Replace(Text.Substring(0, SelectionStart), @"(\w)?\w*$", "");
	Text = text + Text.Substring(SelectionStart);
	SelectionStart = text.Length;
    }
