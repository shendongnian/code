    var names = new[] { "Paul", "John", "George", "Ringo" };
    var dates = new[] { new DateTime(2018, 1, 1), new DateTime(2018, 1, 2),
        new DateTime(2018, 1, 3) };
    
    var missingUsersByDate = submissions
        .GroupBy(s => s.ProcessedDate)
        .Select(g => new { ProcessDate = g.Key,
            MissingUsers = names.Except(g.Select(s => s.UserName)) })
        .Where(g => g.MissingUsers.Any())
        .ToDictionary(k => k.ProcessDate, v => v.MissingUsers);
    
    // Paul, John
    var missingUsers = missingUsersByDate[new DateTime(2018, 1, 3)];
