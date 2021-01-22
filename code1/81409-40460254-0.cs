    Dictionary<int, string> List1 = new Dictionary<int, string>();
    List1.Add(1,"");
    List1.Add(2,"");
    List1.Add(3,"");
    List1.Add(4,"");
    List1.Add(5,"");
    List1.Add(6,"");
    Dictionary<int, string> List2 = new Dictionary<int, string>();
    List2.Add(2, "two");
    List2.Add(4, "four");
    List2.Add(6, "six");
            
    var Result = List1.Select(x => new KeyValuePair<int, string>(x.Key, List2.ContainsKey(x.Key) ? List2[x.Key] : x.Value)).ToList();
