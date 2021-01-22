    public string PrefixFormatString(string p, string s, List<object> par)
    { 
        return p + string.Format(s, par.ToArray());
    }
    ...
    List<object> l = new List<object>(new object[] { errNum, errStr });
    PrefixFormatString("COM", "Output Error #{0} - Error = {1}", l);
