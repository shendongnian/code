     DateTime lclUtc = DateTime.UtcNow;
     DateTime ept = lclUtc.AddHours(IsDaylightSavingTime(lclUtc )? -5: -4)
  
     private static bool IsEasternDaylightSavingTime(DateTime utcDateTime)
       {
            // hard coded method to determine 
            // whether utc datetime is Eastern Standard time
            // or Eastern Daylight Time
       }
