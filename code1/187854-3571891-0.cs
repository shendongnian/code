    private static void CreateListString(string s)
    {
    string[] splits = s.Split(new char[] { ',' });
    List<string> strs = new List<string>();
    bool isLimiterSeen = false;
    StringBuilder str = null;
    for (int i = 0; i < splits.Length; i++)
    {
    if (splits[i].Contains("#("))
    {
    isLimiterSeen = true;
    str = new StringBuilder();
    }
    if (!isLimiterSeen)
    strs.Add(splits[i]);
    else
    {
    str = str.Append("," + splits[i]);
    if (splits[i].EndsWith(")"))
    {
    if (str.ToString().StartsWith(","))
    strs.Add(str.ToString().Substring(1));
    else
    strs.Add(str.ToString());
    isLimiterSeen = false;
    str = null;
    }
    }
    }
    }
