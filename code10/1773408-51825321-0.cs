    var mergedList = new List<string>();
    for(int i=0; i<initialList.Count; ){
        var n = _random.Next(2,4);
        mergedList.Add(initialList.Skip(i).Take(n).Aggregate((x,y) => x + y));
        i += n;
    }
