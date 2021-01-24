    await _context
                .Orders
                .Where(i => i.DepartmentId != null && i.DepartmentId.Equals(Parameters.DepartmentId))
                .Where(i => i.SchoolYear.Equals(Parameters.SchoolYear))
                // Group the data.
                .GroupBy(orders => new
                {
                    orders.BooklistId,
                    orders.BooklistName,
                    orders.OrganizationId,
                    orders.DepartmentId,
                    orders.LocationName,
                    orders.Group1,
                    orders.Group2,
                    orders.Group3
                })
                .OrderBy(i => i.Key.BooklistName)
    .Select(i => new
                {
                    Count = i.Select(orders => orders.OrdererId).Distinct().Count(s => s != null),
                    i.Key.OrganizationId,
                    i.Key.BooklistName,
                    i.Key.LocationName,
                    i.Key.BooklistId,
                    i.Key.Group1,
                    i.Key.Group2,
                    i.Key.Group3,
                    i.Key.DepartmentId,
                    ExpectedDate = i.Max(orders => orders.ExpectedDate)
                })
                .Select(i => new BookListViewModel
                {
                    Count = i.Count,
                    Id = i.Id,
                    Name = i.Name,
                    LocationName = i.LocationName,
                    Number = i.Number ,
                    Group1 = i.Group1 ,
                    Group2 = i.Group2,
                    Group3 = i.Group3,
                    DepartmentId = i.DepartmentId,
                    ExpectedDate = i.ExpectedDate
                })
                .ToListAsync();
