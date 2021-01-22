    public string ReturnCleanASCII(string s)
    {
        StringBuilder sb = new StringBuilder(s.Length);
        foreach(char c in s)
        {
           if((int)c > 127) // you probably don't want 127 either
              continue;
           if((int)c < 32)  // I bet you don't want control characters 
              continue;
           if(c == ',')
              continue;
           if(c == '"')
              continue;
           sb.Append(c);
        }
        return sb.ToString();
    }
