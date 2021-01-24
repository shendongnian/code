    var result = db.Students
        .GroupBy(en => en.Class)
        .Select(g => new {
            Class = g.Key
        ,   Accepted = g.Count(en => en.Progress == MyEnum.Accepted)
        ,   NotAccepted = g.Count(en => en.Progress < MyEnum.Accepted)
        })
        .Where(g => g.Accepted != 0)
        .ToList();
