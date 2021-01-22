    public string rev(string str)
    {
        if (str.Length <= 0)
            return string.Empty;
        else
            return str[str.Length-1]+ rev(str.Substring(0,str.Length-1));
    }
