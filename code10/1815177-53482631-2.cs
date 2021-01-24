    if (list == null)
        throw new ArgumentNullException(...);
    // Get rid of unused items and sort:
    var actual = list
        .Where(item => item.start >= _earliestDate)
        .OrderByDescending(item => item.start)
        .ToArray();
    // If there are no matching items, then return empty array or throw exception
    // It depends on your requirements
    if (actual.Length == 0)
        return actual; 
    // Take the least date in resulted array...
    var earliestInActual = actual[actual.Length - 1]; 
    
    // ...and replace it with _earliestDate
    for (int i = actual.Length - 1; i >= 0; i--)
    {
        if (actual[i].start != earliestInActual)
            break;
        item.start = _earliestDate;  
    }
    return actual;
