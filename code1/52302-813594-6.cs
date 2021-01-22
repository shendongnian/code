    string[] strArray = { "aa", "bb", "xx", "cc", "xx", "dd", "ee", "ff", "xx", "xx", "gg", "xx"};
    var result = strArray.Aggregate(new { C = (IEnumerable<string>)null, 
              L = (IEnumerable<IEnumerable<string>>)new IEnumerable<string>[0] },
      (a, s) => s == "xx" ? a.C == null ?
          new {C=new string[0].AsEnumerable(), a.L} : 
          new {C=new string[0].AsEnumerable(), L=a.L.Union(new[]{a.C})} : 
        a.C == null ? a : new {C=a.C.Union(new[]{s}), a.L}).L.Where(l => l.Any());
    foreach (var i in result)
        Console.WriteLine(String.Join(",", i.ToArray()));
