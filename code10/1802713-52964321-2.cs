    // Not shallow copy (copy shares items with originalList)
    // List<DataPair> copy = new List<DataPair>(originalList.AsReadOnly()); 
    // But deep copy:
    List<DataPair> copy = new List<DataPair>();
    // copy has its own items (new DataPair...)
    foreach (var item in originalList)
      copy.Add(new DataPair(item.Price, item.Volume)); 
