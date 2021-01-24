    var results = new Dictionary<string, int>();
    foreach (var item in list)
    {
        int total = 0;
        if (results.TryGetValue(item.ThisName, out total))
        {
            results[item.ThisName] = total + item.ThisNumber;
        }
        else
        {
            results.Add(item.ThisName, item.ThisNumber);
        }
    }
