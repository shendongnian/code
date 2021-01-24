    var projectPartCounts = context.ProjectParts.AsNoTracking()
        .GroupBy(pp => new { pp.CategoryName, pp.Project.User.UserName })
        .Select(g => new PropjectPartsViewModel {
            Category = g.Key.CategoryName,
            Name = g.Key.UserName,
            PartsCount = g.Count(),
            PartsExistCount = g.Count(pp => pp.PartsExist == true)
        })
        .ToList();
