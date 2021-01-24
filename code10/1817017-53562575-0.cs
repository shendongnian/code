    foreach(var prop in obj1.GetType().GetProperites().Zip(obj2.GetType().GetProperties(), (a,b) => Tuple.Create(a,b))
    {
        var name1 = prop.Item1.Name;
        var name2 = prop.Item2.Name;
        var value1 = prop.Item1.GetValue(obj1, null);
        var value2 = prop.Item2.GetValue(obj2, null);
        // do things
    }
