    public string RemoveCharactersBeforeDot(string s)
    {
     string splitted=s.Split('.');
     return splitted[splitted.Length-1]
    }
