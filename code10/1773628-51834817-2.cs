    List<DateTime> dateTimes = new List<DateTime>();
    dateTimes.Add(new DateTime(2018, 8, 14, 08, 20, 05));
    dateTimes.Add(new DateTime(2018, 8, 14, 08, 45, 25));
    dateTimes.Add(new DateTime(2018, 8, 14, 09, 02, 53));
    dateTimes.Add(new DateTime(2018, 8, 14, 09, 34, 12));
    dateTimes.Add(new DateTime(2018, 8, 14, 09, 44, 12));
    
    List<int> ints = new List<int>();
    ints.Add(12);
    ints.Add(15);
    ints.Add(27);
    ints.Add(03);
    ints.Add(12);
    
   
    var averages = dateTimes.Select((k, v) => new { k, v })
                            .GroupBy(x => new DateTime(x.k.Year, x.k.Month, x.k.Day, x.k.Hour, 0, 0))
                            .ToDictionary(g => g.Key, g => g.Select(x => ints.ElementAt(x.v)).Average());
