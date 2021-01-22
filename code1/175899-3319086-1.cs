    // Use the first value in group
    var _people = personList
        .GroupBy(p => p.FirstandLastName, StringComparer.OrdinalIgnoreCase)
        .ToDictionary(g => g.Key, g => g.First(), StringComparer.OrdinalIgnoreCase);
    // Use the last value in group
    var _people = personList
        .GroupBy(p => p.FirstandLastName, StringComparer.OrdinalIgnoreCase)
        .ToDictionary(g => g.Key, g => g.Last(), StringComparer.OrdinalIgnoreCase);
