    string x = "AAABBBCC";
    List<string> a = new List<string>();
    for (int i = 0; i < x.Length; i += 3)
    {
        if((i + 3) < x.Length)
            a.Add(x.Substring(i, 3));
        else
            a.Add(x.Substring(i));
    }
