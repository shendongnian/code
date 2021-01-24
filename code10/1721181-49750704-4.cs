    using System.Text.RegularExpressions;
    string[] Patterns = new string[] { "https://", "http://" };
    if (richTextBox1.SelectedText.Length > 0)
    {
        string text = richTextBox1.SelectedText;
        richTextBox1.SelectedText = Patterns.Select(s => (text = Regex.Replace(text, s, string.Empty, RegexOptions.IgnoreCase))).Last();
    }
