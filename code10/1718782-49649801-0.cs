    var grouped = tasks
        .GroupBy(t => t.Action, (k, g) => g
            .Segment((s, f, a) => s.Source != f.Target)
            .Select(c => new
            {
                c.First().Source,
                c.Last().Target,
                Action = k
            })));
