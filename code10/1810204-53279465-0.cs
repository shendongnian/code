    var list = new List<string>();
    list.Add("Employee1");
    list.Add("Account");
    list.Add("100.5600,A+   ,John");
    list.Add("1.00000,A+     ,John");
    list.Add("USA");
    
    list = list.Select(x => (x, x.Split(','))).GroupBy(x => string.Join(",", x.Item2.Skip(1).Select(y => y.Trim()))).SelectMany(x => x.Count() > 1 ? x.Select(y => y.Item2[0]) : x.Select(y => y.Item1)).ToList();
