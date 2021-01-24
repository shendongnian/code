    // Normally I'd expect you to have some kind of sequence of privileges rather
    // than separate variables.
    var privileges = new[] { p1, p2 };
    var failures = privileges
        // Group the privileges by 3 properties, extracting actions as the values
        .GroupBy(p => new { p.Type, p.AccessType, p.Value }, p => p.Action)
        // Find any groups which have more than one distinct action
        .Where(g => g.Distinct().Skip(1).Any())
        .ToList();
    if (failures.Count > 0)
    {
        // There's at least one failure. There may be many. Throw
        // whatever exception you want here. This is just an example.
        var individualMessages =
            failures.Select(g => $"{g.Key}: {string.Join(", ", g.Distinct())}");
        throw new Exception(
            $"Invalid privilege combinations: {string.Join("; ", individualMessages})");
    }
