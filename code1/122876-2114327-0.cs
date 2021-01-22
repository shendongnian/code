    public string PrefixFormatString(string p, string s, params object[] par)
    { 
        return p + string.Format(s, par);
    }
    ...
    PrefixFormatString("COM", "Output Error #{0} - Error = {1}", errNum, errStr);
