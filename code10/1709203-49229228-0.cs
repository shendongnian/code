    public static List<List<string>> CrossJoin(List<string[]> arrays)
    {
        var data = arrays.Select(x => x.ToList()).ToList();
        List<List<string>> result = data[0].Select(x => new List<string> { x }).ToList();
    
        for (var i = 1; i < data.Count; i++)
            result = CrossJoinTwoArrays(result, data[i]);
    
        return result;
    }
    
    public static List<List<string>> CrossJoinTwoArrays(List<List<string>> array1, List<string> array2)
    {
        return (from a in array1
                from b in array2
                select new { a, b }).Select(x =>
                {
                    var y = new List<string>(x.a);
                    y.Add(x.b);
                    return y;
                }).ToList();
    }
