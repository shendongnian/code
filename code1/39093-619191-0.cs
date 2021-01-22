    static void AddInc(Dictionary<string, int> dict, string s)
    {
        if (dict.ContainsKey(s))
        {
            dict[s]++;
        }
        else
        {
            dict.Add(s, 1);
        }
    }
