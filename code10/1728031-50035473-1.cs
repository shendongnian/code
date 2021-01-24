    var tzInfo = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
    // This is the only change, except replacing the space with \n in the Console.WriteLine:
    //var reminderstarttime = new DateTime(2018, 3, 10, 22, 0, 0);
    var reminderstarttime = new DateTime(2018, 3, 10, 22, 0, 0, DateTimeKind.Local);
    var referencetime = reminderstarttime.AddHours(10);  // ReferencedTime is in DST;
    var isRemDstWithNormal = tzInfo.IsDaylightSavingTime(reminderstarttime);
    var isRefDstWithNormal = tzInfo.IsDaylightSavingTime(referencetime);
    var reminderStartTimeToUtc = reminderstarttime.ToFileTimeUtc();
    var referenceTimeToUtc = referencetime.ToFileTimeUtc();
    var reminderStartTimeFromUtc = DateTime.FromFileTimeUtc(reminderStartTimeToUtc);
    var referencetimeFromUtc = DateTime.FromFileTimeUtc(referenceTimeToUtc);
    var isRemDSTFromFileTime = tzInfo.IsDaylightSavingTime(reminderStartTimeFromUtc);
    var isRefTimeDSTFromFileTime = tzInfo.IsDaylightSavingTime(referencetimeFromUtc);
    Console.WriteLine("isRemDstWithNormal: " + isRemDstWithNormal + 
                     "\nisRefDstWithNormal: " + isRefDstWithNormal + 
                     "\nisRemDSTFromFileTime " + isRemDSTFromFileTime + 
                     "\nisRefTimeDSTFromFileTime: " + isRefTimeDSTFromFileTime);
