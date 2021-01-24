    // Notice that the object is in local time now.
    var dateObj = new DateTime(2017, 6, 1, 9, 0, 0);
    long dateInLong = dateObj.ToUTC();
    Console.WriteLine(dateInLong);
    Console.WriteLine(dateInLong.ToDateTime());
