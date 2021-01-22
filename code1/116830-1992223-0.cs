    string text = Encoding.ASCII.GetString(data);
    foreach (string delim in DelimiterStrings)
        text = text.Replace(delim, "\n");
    foreach (string line in text.Split(DelimiterChars))
    {
        // processing here
    }
