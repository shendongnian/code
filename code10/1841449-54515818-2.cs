    var result = itemsWithYearMonth
        // keep only the items newer than startMonth
        .Where(item => item.DateTime >= startMonth)
        // group by same month:
        .GroupBy(item => item.DateTime.Month,
        (month, itemsWithThisMonth) => new
        {
            Month = month,        // in my example: 11, 12, 1, ...
            // in every group: take the first nrOfYears items:
            Items = itemsWithThisMonth
                    // order by ascending year
                    .OrderBy(itemWithThisMonth => itemWithThisMonth.Year)
                    // no need to order by Month, all Months are equal in this group
                    .Take(nrOfYears)
                    .ToList(),
         })
         // keep only the desired months:
         .Select(group => desiredMonth.Contains(group.Month));
