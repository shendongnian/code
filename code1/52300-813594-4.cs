    string[] strArray = { "aa", "bb", "xx", "cc", "xx", "dd", "ee", "ff", "xx", "xx", "gg", "xx"};
    var result = strArray.Aggregate(new { Current = (IEnumerable<string>)null, List = (IEnumerable<IEnumerable<string>>)new IEnumerable<string>[0] },
        (a, s) => s == "xx" ? 
          a.Current == null ? new { Current = new string[0].AsEnumerable(), a.List } : 
                              new { Current = new string[0].AsEnumerable(), 
                                    List = a.List.Union(new [] { a.Current }) } : 
          a.Current == null ? a : new { Current = a.Current.Union(new[] { s }), 
                                        a.List }).List.Where(l => l.Any());
    foreach (var i in result)
        Console.WriteLine(String.Join(",", i.ToArray()));
