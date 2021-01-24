    int referenceNumber = 5;
    int? closestLowerNumber = null;
    int? closestHigherNumber = null;
    
    foreach (var i in Test)
    {
        if (i < referenceNumber)
        {
            if (!closestLowerNumber.HasValue || closestLowerNumber < i)
            {
                closestLowerNumber = i;
            }
        }
        else if (i > referenceNumber)
        {
            if (!closestHigherNumber.HasValue || closestHigherNumber > i)
            {
                closestHigherNumber = i;
            }
        }
    }
    
    Console.WriteLine(
        $"{referenceNumber}:{referenceNumber - closestLowerNumber}:{closestHigherNumber - referenceNumber}");
