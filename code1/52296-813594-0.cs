    string[] strArray = { "aa", "bb", "xx", "cc", "xx", "dd", "ee", "ff", "xx", "xx", "gg", "xx" };
    var result = strArray.Aggregate(new List<List<string>> { new List<string>() },
                             (acc, currentString) => { 
                                 if (currentString == "xx") 
                                      acc.Add(new List<string>()); 
                                 else 
                                      acc.Last().Add(currentString); 
                                 return acc; })
                         .Where(list => list.Any());
    foreach (var item in result)
         Console.WriteLine(string.Join(",", item.ToArray()));
