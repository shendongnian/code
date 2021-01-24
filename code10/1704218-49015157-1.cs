    var asc = allN.Concat(ints.Concat(doubles)
      .OrderBy(x => x).Cast<object>()).ToArray();
    var desc = ints.Concat(doubles)
      .OrderByDescending(x => x).Cast<object>().Concat(allN).ToArray();
    
    
