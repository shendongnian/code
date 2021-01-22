    string rule = "1 AND 2 AND 3 OR 4";
    List<string> andsOrs = new List<string>();
    string[] split = rule.Split();
    for (int i = 0; i < split.Length; i++)
    {
       if (split[i] == "AND" || split[i] == "OR")
       {
           andsOrs.Add(split[i]);
       }
    }
    string[] conditions = andsOrs.ToArray();
    return conditions;
