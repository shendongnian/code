    // We don't know the actual type here - I'm guessing
    IOrderedQueryable<Employee> ordered;
    switch (filters.Sort)
    {
        case "new":
            ordered = query.OrderByDescending(a => a.CreatedAt);
            break;
        case "old":
            ordered = query.OrderBy(a => a.CreatedAt);
            break;
        case "salary-asc":
            ordered = query.OrderBy(a => a.Profile.CompensationTypeRate.FromCompensation);
        default:
            // You need to work out what you want to do here. Maybe just
            // order by ID? You need to order by *something* to start with
            // in order to use ThenBy
    }
    // Apply the same secondary ordering, regardless of the primary one
    ordered = ordered.ThenBy(x => x.Grade);
