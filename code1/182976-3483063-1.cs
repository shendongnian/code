    var categoryId = ...;
    var infoClasses = db.CategoryInformation
        .Where(cinf => db.CategoryTC.Where(tc => tc.Descendant == categoryId)
                                    .Any(tc => tc.Ancestor == cinf.CategoryId))
        .Select(cinf => db.InformationClass
                          .FirstOrDefault(ic => ic.Id == cinf.InformationClassId));
