    static string BadConcatenate(string[] items)
    {
        string strRet = string.Empty;
    
        foreach(string item in items)
        {
            strRet += item;
        }
    
        return strRet;
    }
