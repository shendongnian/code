    List<int?> ints = new List<int?>();
    foreach (string str in strs)
    {
        int val;
        if (int.TryParse(str, out val))
        {
            ints.Add(val);
        }
        else { ints.Add(null); }
    }
    return ints.ToArray();
