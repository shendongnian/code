    public string Transform(string data)
    {
        string result = data;
        char cr = (char)13;
        char lf = (char)10;
        char tab = (char)9;
        result = result.Replace("\\r", cr.ToString());
        result = result.Replace("\\n", lf.ToString());
        result = result.Replace("\\t", tab.ToString());
        return result;
    }
