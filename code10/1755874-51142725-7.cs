    // dateObj will have time 2017/6/1 9:00:00 _in UTC_.
    var dateObj = new DateTime(2017, 6, 1, 9, 0, 0, DateTimeKind.Utc);
    // This method converts to UTC, but it's already in UTC, so no actual conversion takes place.
    // Then subtracts UnixEpoch from it, which is also in UTC. 
    long dateInLong = dateObj.ToUTC();
    // The difference is one hour, so dateInLong will be 3600.
    Console.WriteLine(dateInLong);
    // This method adds the above difference to UnixEpoch, and displays the time.
    Console.WriteLine(dateInLong.ToDateTime());
