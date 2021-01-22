    StringBuilder sb = new StringBuilder();
    foreach(char c in sr.ReadToEnd())
    {
        if (c != '\r' && c != '\n')
            sb.Append(c);
    }
    string str = sb.ToString();
