    if (list == null)
        throw new ArgumentNullException(...);
    // Get rid of unused items and sort:
    var actual = list
        .Where(item => item.start > _earliestDate)
        .OrderBy(item => item.start)
        .ToArray();
    // If there are no matching items, then return empty array or throw exception
    // It depends on your requirements
    if (actual.Length == 0)
        return actual; 
    // Take the least date in resulted array...
    var earliestInActual = actual[0].start; 
    
    // ...and replace it with _earliestDate
    foreach (var item in actual)
    {
        if (item.start != earliestInActual)
            break;
        item.start = _earliestDate;  
    }
    return actual;
