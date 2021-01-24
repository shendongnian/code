    Console.WriteLine(@"Enter Lower");
    var lower = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
    Console.WriteLine(@"Enter Upper");
    var upper = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
    using (var db = new forTestEntities())
    {
        var newCondition = new tblCondition
        {
            Lower = lower,
            Upper = upper
        };
        var range = Enumerable.Range(newCondition.Lower, 
                                newCondition.Upper - newCondition.Lower + 1);
        var check = db.tblConditions.AsEnumerable().Any(c => range
                    .Intersect(Enumerable.Range(c.Lower, c.Upper - c.Lower + 1)).Any());
        if (!check)
        {
            db.tblConditions.Add(newCondition);
            db.SaveChanges();
        }
    }
