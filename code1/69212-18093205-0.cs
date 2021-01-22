    var ld1 = new LocalDate(2012, 1, 1);
    var ld2 = new LocalDate(2013, 12, 25);
    var period = Period.Between(ld1, ld2);
            
    Debug.WriteLine(period);        // "P1Y11M24D"  (ISO8601 format)
    Debug.WriteLine(period.Years);  // 1
    Debug.WriteLine(period.Months); // 11
    Debug.WriteLine(period.Days);   // 24
