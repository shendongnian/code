        var list = new List<string> { "me", "you", "meyou", "mow" };
        var predicates = new List<Predicate<string>>();
        predicates.Add(i => i.Contains("me"));
        predicates.Add(i => i.EndsWith("w"));
        var results = new List<string>();
        foreach (var p in predicates)
            results.AddRange(from i in list where p.Invoke(i) select i);               
