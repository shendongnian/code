    var query = myList
        .GroupBy(c => c.TimeStamp)
        .Select(g => new {
            TimeStamp = g.Key,
            Prop1 = g.Where(c => c.Name == "Prop1").Sum(c => c.Value),
            Prop1 = g.Where(c => c.Name == "Prop2").Sum(c => c.Value),
            Prop3 = g.Where(c => c.Name == "Prop3").Sum(c => c.Value),
        });
