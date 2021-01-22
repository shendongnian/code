    public string NumberOrLetterOnly(string s)
    {
        string rtn = s;
        for (int i = 0; i < s.Length; i++)
        {
            if (!char.IsLetterOrDigit(rtn[i]) && rtn[i] != '-')
            {
                rtn = rtn.Replace(rtn[i].ToString(), " ");
            }
        }
        return rtn.Replace(" ", "");
    }
