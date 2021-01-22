    private readonly static string reservedCharacters = "!*'();:@&=+$,/?%#[]";
    
    public static string UrlEncode(string value)
    {
        if (String.IsNullOrEmpty(value))
            return String.Empty;
 
        var sb = new StringBuilder();
 
        foreach (char @char in value)
        {
            if (reservedCharacters.IndexOf(@char) == -1)
                sb.Append(@char);
            else
                sb.AppendFormat("%{0:X2}", (int)@char);
        }
        return sb.ToString();
    }
