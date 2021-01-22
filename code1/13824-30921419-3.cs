    public bool IsHexString(string value)
    {
        string hx = "0123456789ABCDEF";
        foreach (char c in value.ToUpper()) {
            if (!hx.Contains(c))
            return false;
        }
        return true;
    }
