    int thisYear = DateTime.UtcNow.Year;
    int lastYear = thisYear - 1;
    var query = MyCollection
        .Where(item => item.Year >= lastYear)
        .GroupBy(item => new {Year = item.Year, Month = item.Month), // Key
            item => item.Amount)                                     // Values
        // only if you want some ordering:
        .OrderBy(group => group.Key.Year)
        .ThenBy(group => group.Key.Month)
        // calculate the sum of all items in the group. Remember the year and the month
        .Select(group => new
        {
            Year = group.Key.Year,           // omit if you won't use this
            Month = group.Key.Month,
            Sum = group.Sum(),
         });
    var thisYearsResult = query.Where(fetchedItem => fetchedItems.Year == thisYear)
        .FirstOrDefault();
