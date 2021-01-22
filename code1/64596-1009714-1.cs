    public string ReverseString(string sz)
    {
        var builder = new StringBuilder(sz.Length);
        for(int i = sz.Length-1; i>=0; i--)
        {
          builder.Append(sz[i]);
        }
        return builder.ToString();
    }
