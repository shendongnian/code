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
