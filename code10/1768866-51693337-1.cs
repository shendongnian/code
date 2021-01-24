    Console.WriteLine("Enter your age");
    var age = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
    using (var db = new forTestEntities())
    {
        var result = db.tblConditions.Where(c => c.Lower <= age && age <= c.Upper).AsEnumerable()
            .Select(c => $"Range {c.Lower} - {c.Upper}").DefaultIfEmpty("Over range").SingleOrDefault();
        Console.WriteLine(result);
    }
