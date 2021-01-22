    string[] strArray = { "aa", "bb", "xx", "cc", "xx", "dd", 
                          "ee", "ff", "xx", "xx", "gg", "xx" };
 
    var result = 
     strArray.Aggregate((IEnumerable<IEnumerable<string>>)new IEnumerable<string>[0],
       (a, s) => s == "xx" ? a.Union(new[] { new string[0] })
          : a.Any() ? a.Except(new[] { a.Last() })
                       .Union(new[] { a.Last().Union(new[] { s }) }) : a)
             .Where(l => l.Any());
    // Test
    foreach (var i in result)
      Console.WriteLine(String.Join(",", i.ToArray()));
