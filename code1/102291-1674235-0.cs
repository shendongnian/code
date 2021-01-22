    // First make a System.DateTime equivalent to the UNIX Epoch.
    System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
    // Add the number of seconds in UNIX timestamp to be converted.
    dateTime = dateTime.AddSeconds(numSeconds);
    // Then add the number of milliseconds
    dateTime = dateTime.Add(TimeSpan.FromMilliseconds(numMilliseconds));
