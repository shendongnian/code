    private List<char> GetChars()
    {
        List<char> charsToPopulate = new List<char>();
        foreach(Thing t in Things)  
        {  
           charsToPopulate.Add(t.CharSymbol);  
        }  
        return charsToPopulate;
    }
