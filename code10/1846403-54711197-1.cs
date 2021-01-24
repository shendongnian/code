    //normalizing data and make a list of joined columns
    var normalizedlist = IdsList
    .Select((Ids, index) => new { Ids = Ids, ShippingNumbers = ShippingNumbersList[index].Split(',') })
        .ToList();
    //for each distinct ShippingNumber find and write respective Id
    foreach (var ShippingNumber in normalizedlist.SelectMany(x=>x.ShippingNumbers).Distinct())
    {
        //fitering and then grouping by date 
        var filtered = normalizedlist.Where(y => y.ShippingNumbers.Contains(ShippingNumber))
            .GroupBy(y => y.Ids.Split('-')[1])
            .Where(y => y.Count() > 1)
            .Select(y => y.Select(z=>z.Ids));
        foreach (var date in filtered)
        {
        Console.WriteLine($"{ShippingNumber}>>{string.Join(",",date.ToArray())}");
        }
    }
   
