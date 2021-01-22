    pointList.Sort(); // Use you own compare here if needed
    // Skip OrderBy because the list is sorted (and not copied)
    double cutoffValue = pointList.ElementAt((int) pointList.Length * (1 - N)).Z; 
    // Skip ToList to avoid another copy of the list
    IEnumerable<Point> selectedPoints = pointList.Where(p => p.Z >= cutoffValue); 
