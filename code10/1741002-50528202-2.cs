    var from = new DateTime(2018, 5, 28);
    var to = new DateTime(2018, 6, 4);
    
    var result = Enumerable.Range(0, int.MaxValue)
                           .Select(i => from.Date.AddDays(i))
                           .TakeWhile(date => date <= to.Date)
                           .GroupBy(date => date.Month)
                           .Select(range => (Month: range.Key, Days: range.Count()));
    foreach (var month in result)
    {
        Console.WriteLine($"Month: {month.Month}, Seek days: {month.Days}");
    }
    // result:
    // Month: 5, Seek days: 4
    // Month: 6, Seek days: 4
