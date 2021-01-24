    var comparedToDates = itCompareDay.Where(dy => dy.EventType == "SE")
                                      .Where(dy => dy.Date >= startDate.Date)
                                      .ToList();
    return
       itCompareDay.Where(dy => dy.EventType == "SS")
                   .Where(dy => dy.Date == startDate.Date); // Compare this way instead 
                   .Any(SS => comparedToDates.Any( SE => SS > SE )); // Let it 
                                                                     // work the compare
          
