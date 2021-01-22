    public string ReplaceBackspace(string hasBackspace)
    {
        if( string.IsNullOrEmpty(hasBackspace) )
            return hasBackspace;
        StringBuilder result = new StringBuilder(hasBackspace.Length);
        foreach (char c in hasBackspace)
        {
            if (c == '\b')
            {
                if (result.Length > 0)
                    result.Length--;
            }
            else
            {
                result.Append(c);
            }
        }
        return result.ToString();
    }
