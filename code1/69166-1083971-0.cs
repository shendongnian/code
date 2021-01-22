    DateTime dt1 = new DateTime(2009, 3, 14);
    DateTime dt2 = new DateTime(2008, 3, 15);
    TimeSpan ts = dt1.Subtract(dt2);
    Double days = ts.TotalDays;
    Double hours = ts.TotalHours;
    Double years = ts.TotalDays / 365;
