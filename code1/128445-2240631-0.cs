    List<string> filteredCombinations = new List<string>();
    //For each collection in the combinated results collection
    foreach (var combinatedValues in combinatedResults)
    {
        var subCombinations = combinatedValues.Where(v => v > 0)
                                              .Select(v => v.ToString())
                                              .ToList();
        if (subCombinations.Count > 0)
           filteredCombinations.Add(string.Join(",",subCombinations.ToArray()));
    }
