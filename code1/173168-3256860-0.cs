    // The type of list will be List<T> where T is the anonymous type
    var list = new[]
    {
        new { Name = "North By Northwest", Year = 1959 },
        new { Name = "The Green Mile", Year = 1999},
        new { Name = "The Pursuit of Happyness", Year = 2006}
    }.ToList();
    list.ForEach(x => Console.WriteLine("{0} ({1})", x.Name, x.Year));
