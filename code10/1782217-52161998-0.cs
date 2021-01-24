    List<Tuple<int,string>> list = new List<Tuple<int,string>>();
    list.Add(Tuple.Create(23, "Foo"));
    list.Add(Tuple.Create(23, "Bar"));
    list.Add(Tuple.Create(25, "Bar"));
    var keys = list.Where(x=> x.Item1 == 23).Select(x=> x.Item2); // FOO, BAR
    var values = list.Where(x=> x.Item2 == "Bar").Select(x=> x.Item1); ; // 23, 25
