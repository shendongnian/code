    List<string> list;
    if (!theDictionary.TryGetValue(key, out list)) {
      theDictionary.Add(list = new List<string>());
    }
    if (list.Count == 50) {
      list.RemoveAt(0);
    }
    list.Add(line);
