    foreach (KeyValuePair<string, List<string>> item in dict1) {
      otherEntry.Add(item);
      if (dict2.ContainsKey(item.Key)) {
        dict2.Remove(item.Key);
      }
    }
