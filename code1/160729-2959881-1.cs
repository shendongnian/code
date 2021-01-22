    static public string NormalizeVersionString(string versionString)
    {
        if(versionString == null)
           throw new NullArgumentException("versionString");
        bool insideNumber = false;    
        StringBuilder sb = new StringBuilder(versionString.Length);
        foreach(char c in versionString)
        {
            if(c == '.')
            {
                sb.Append('.');
                insideNumber = false;
            }
            else if(c >= '1' && c <= '9')
            {
                sb.Append(c);
                insideNumber = true;
            }
            else if(c == '0')
            {
                if(insideNumber)
                    sb.Append('0');
            }
        }
        return sb.ToString();
    }
