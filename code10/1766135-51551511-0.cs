    List<DateTime> dt = new List<DateTime>
    {
        new DateTime(2018,7,26,14,0,0),// 26-July-2018 14:00:00
        new DateTime(2018,7,27,12,9,0),//27 - July - 2018 12:09:00
        new DateTime(2018,7,27,12,10,0),//27 - July - 2018 12:10:00
        new DateTime(2018,7,27,12,15,0),//27 - July - 2018 12:15:00
        new DateTime(2018,7,28,12,50,0),//28 - July - 2018 12:50:00
        new DateTime(2018,7,28,13,40,0)//28 - July - 2018 13:40:00
    };
    List<double> dbl = dt.Select(d => d.ToOADate()).ToList();
    DateTime startDate = new DateTime(2018, 7, 27, 12, 15, 0);
    double startDateDbl = (new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0)).ToOADate();
    List<double> filteredDates = dbl.Where(d => d >= startDateDbl).ToList();
