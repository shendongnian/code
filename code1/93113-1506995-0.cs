    public static bool IsFirstDayOfMonth(this DateTime t) {
      var other = new DateTime(t.Year,t.Month,1);
      return other == t.Date;
    }
    
    var allDates = GetTheDates();
    var filter = allDates.Where(x => x.IsFirstDayOfMonth());
