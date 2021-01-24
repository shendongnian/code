    public static List<List<string>> CrossJoin(List<string[]> arrays)
    {
        var data = arrays.Select(x => x.ToList()).ToList();
        List<List<string>> result = data[0].Select(x => new List<string> { x }).ToList();
    
        for (var i = 1; i < data.Count; i++)
            result = (from a in result
                      from b in data[i]
                      select new { a, b }).Select(x =>
                      {
                          var y = new List<string>(x.a);
                          y.Add(x.b);
                          return y;
                      }).ToList();
    
        return result;
    }
