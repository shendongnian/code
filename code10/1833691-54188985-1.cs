    List<AnalysisPerDay> analysis = measurements.
        GroupBy(m => m.Date)
        .Select(g => new AnalysisPerDay {
            Date = g.Key,
            Count = g.Count(),
            Min = g.Min(m => m.Value),
            Max = g.Max(m => m.Value),
            Average = g.Average(m => m.Value),
        })
        .ToList();
