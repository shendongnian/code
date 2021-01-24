    var query = MyCollection
        .Where(item => item.Year >= lastYear)
        .GroupBy(item => item.Year)
        // every group  has Year as key, and all items of that year as elements
        .Select(group => new
        {
             Year = group.Key,
             AmountsPerMonth = group.GroupBy(groupItem => groupItem.Month)
                 // every subGroup has the same Year and Month
                 .Select(subGroup => new
                 {
                     Month = subGroup.Key,
                     Sum = subGroup.Select(subGroupItem => subGroupItem.Amount).Sum(),
                 }),
        });
