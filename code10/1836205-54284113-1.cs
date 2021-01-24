    public string GetSubString(string input, char delim)
    {
        var index = input.IndexOf(delim);
    
        return index == -1 ? input : input.Substring(index + 1);
    }
