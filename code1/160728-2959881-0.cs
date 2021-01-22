    static public string NormalizeVersionString(string versionString)
    {
        if(versionString == null)
           throw new NullArgumentException("versionString");
    
        StringBuilder sb = new StringBuilder(versionString.Length);
        foreach(char c in versionString)
        {
            if(c == '.')
                sb.Append('.');
            else if(c >= '1' && c <= '9')
                sb.Append(c);
        }
        return sb.ToString();
    }
