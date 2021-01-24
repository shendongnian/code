    public static String LongestConsec(string[] strarr, int k)
    {
        var dict = new Dictionary<string, int>();
        for (int i = 0; i < strarr.Length; i++)
        {
            if (!dict.ContainsKey(strarr[i]))  // Preventing duplicates
            {
                dict.Add(strarr[i], i + 1);
            }
        }
        string final = String.Join("",
            dict.OrderByDescending(s => s.Key.Length)
                .Take(k)
                .OrderBy(s => s.Value)
                .Select(s => s.Key)
        );
        return final;
    }
