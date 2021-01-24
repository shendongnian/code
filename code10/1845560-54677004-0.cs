    IDictionary<string, IList<string>> names = new Dictionary<string, IList<string>>();
    names.Add("alice", new List<string>());
    names.Add("bob", new List<string>());
    names.Add("curt", new List<string>());
    foreach (KeyValuePair<string, IList<string> name in names)
    {
        for (int i = 0; i < name.Key.Length; i++)
        {
            string newName = name.Key.Substring(0, i) + name.Key.Substring(i + 1);
            if (!name.Value.Contains(newName))
            {
                modNames[nameIndex].Add(newName);
            }
        }
    }
