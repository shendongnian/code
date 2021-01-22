    string input = "lAl_058a_068b_COMP_dsj_V001.txt";
    string regex = @"^(?<Group1>[a-z][a-z0-9]{1,2})_(?<Group2>\d{3}[a-z]{0,2})_(?<Group3>[a-z-]+)_(?<Group4>v\d{3,5})$";
    
    StringBuilder sb = new StringBuilder(input);
    Match m = Regex.Match(input, regex, RegexOptions.IgnoreCase | RegexOptions.Multiline);
    if (m.Success)
    {
        Group g;
        g = m.Groups["Group1"];
        sb.Replace(g.Value, g.Value.ToUpper(), g.Index, g.Length);
        g = m.Groups["Group2"];
        sb.Replace(g.Value, g.Value.ToLower(), g.Index, g.Length);
        g = m.Groups["Group4"];
        sb.Replace(g.Value, g.Value.ToLower(), g.Index, g.Length);
    }
