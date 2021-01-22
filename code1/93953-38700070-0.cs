    public string ReturnASCII(string s)
    {
        StringBuilder sb = new StringBuilder(s.Lenght);
        foreach(char c in s.ToCharArray())
        {
           if((int)c > 127)
              continue;
           sb.Append(c);
        }
        return sb.ToString();
    }
