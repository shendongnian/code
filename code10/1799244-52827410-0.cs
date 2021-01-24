    var myFilteredList = myList
        .GroupBy(_ => (int)_.WorkOrderID, (k, g) =>
        {
            var recent = g.OrderByDescending(_ => _.LastUpdatedAt).First();
            return new
            {
                WorkOrderID = k,
                LastUpdatedAt = (DateTime)recent.LastUpdatedAt,
                Col3 = (string)recent.Col3,
                Col4 = (string)recent.Col4
            };
        });
