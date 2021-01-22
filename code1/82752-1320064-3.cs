    DateTime stamp = /* get datetime from the database here, make sure you
                        use the constructor that allows you to specify the 
                        DateTimeKind as UTC. */
    //E.g.
    //DateTime stamp = new DateTime(2009, 12, 12, 12, 12, 12, DateTimeKind.Utc);
    timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(" /* users time zone here */"); 
    var convertedTime = TimeZoneInfo.ConvertTime(stamp, timeZoneInfo);
    
    //Print out the date and time
    //Console.WriteLine(convertedTime.ToString("yyyy-MM-dd HH-mm-ss")); 
