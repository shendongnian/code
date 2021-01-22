    Dictionary<string, float> clrs = new Dictionary<string, float>();
    float i = 0;
    foreach (string s in largeList)
        clrs.Add(s, i++);
    float lastIndex = 0;
    for (int j = 0; j < smallList.Count; j++)
    {
        if (largeList.Contains(smallList[j]))
            lastIndex = clrs[smallList[j]];
        else
            clrs.Add(smallList[j], lastIndex + 0.5f);
    }
    var sorted = from c in clrs.Keys orderby clrs[c] select c;
    return sorted.ToList<string>();
