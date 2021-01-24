    var source = new List<int>() { 1, 2, 3 };
    var target = new List<List<int>>();
    for(var i = 0; i < source.Count; i++)
    {
        for(var j = i; j < source.Count; j++)
        {
            target.Add(new List<int>(source.Skip(i).Take(source.Count - j)));
        }
    }
