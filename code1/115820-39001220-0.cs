    private string SplitCharsAndNums(string text)
    {
        var sb = new StringBuilder();
        for (var i = 0; i < text.Length - 1; i++)
        {
            if ((char.IsLetter(text[i]) && char.IsDigit(text[i+1])) ||
                (char.IsDigit(text[i]) && char.IsLetter(text[i+1])))
            {
                sb.Append(text[i]);
                sb.Append(" ");
            }
            else
            {
                sb.Append(text[i]);
            }
        }
    
        sb.Append(text[text.Length-1]);
    
        return sb.ToString();
    }
