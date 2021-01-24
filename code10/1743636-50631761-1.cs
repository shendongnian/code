    var query = c.Customers
        .GroupBy(s => s.Name, (k, g) => g
            .Select(s => new { MaxGrade = g.Max(s2 => s2.Grade), Student = s }))
        .SelectMany(s => s)
        .OrderBy(s => s.MaxGrade)
        .ThenBy(s => s.Student.Name)
        .ThenByDescending(s => s.Student.Grade)
        .Select(s => s.Student)
        .Skip(toSkip)
        .Take(toTake)
        .ToList();
