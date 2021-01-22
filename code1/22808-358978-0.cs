    StringBuilder pattern = new StringBuilder();
    foreach (string s in arrayOfStringsToRemove)
    {
        pattern.Append("(");
        pattern.Append(Regex.Escape(s));
        pattern.Append(")|");
    }
    Regex.Replace(inputString, pattern.ToString(0, pattern.Length - 1), // remove trailing |
        replacement);
