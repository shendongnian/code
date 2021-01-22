        var groups = Elements.GroupBy(x => new {x.A, x.B, x.C});
        foreach (var group in groups)
        {
            Trace.WriteLine(group.Key + ": " + group.Count());
            foreach (var row in group)
            {
                Trace.WriteLine(row.D);
            }
        }
