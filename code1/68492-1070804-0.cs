    int otherCount = 0;
    int totalCounts = colStates.Values.Sum();
    var newDict = new Dictionary<string,int>();
    foreach (var kv in colStates) {
      if (kv.Value/(double)totalCounts < 0.05) {
        otherCount += kv.Value;
      } else {
        newDict.Add(kv.Key, kv.Value);
      }
    }
    if (otherCount > 0) {
      newDict.Add("Other", otherCount);
    }
    colStates = newDict;
