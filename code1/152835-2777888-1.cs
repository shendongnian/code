    public static string GetParameterizedString(string s)
    {
        var sb = new StringBuilder();
        var sArray = s.Split('?');
        for (var i = 0; i < sArray.Length - 1; i++)
        {
            sb.Append(sArray[i]);
            sb.Append("@P");
            sb.Append(i + 1);
        }
        sb.Append(sArray[sArray.Length - 1]);
        return sb.ToString();
    } 
