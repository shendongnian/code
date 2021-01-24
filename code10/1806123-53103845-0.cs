    var test = new DateTimeOffset(new DateTime(2018, 11, 4, 0, 0, 0));
    var newTime = test.AddHours(2);
    if (test.LocalDateTime.IsDaylightSavingTime() && 
         !newTime.LocalDateTime.IsDaylightSavingTime())
            {
                test = test.AddHours(-1);
            }
