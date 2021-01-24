    DateTime date0 = new DateTime(2018, 8, 9, 20, 59, 59);
    DateTime date1 = new DateTime(2018, 8, 9, 21, 0, 0);
    int hourspassed = HoursSpanned(date0, date1);  // = 1
    
    date0 = new DateTime(2018, 8, 9, 23, 59, 59);
    date1 = new DateTime(2018, 8, 10, 00, 00, 00);
    int daysPassed = DaysSpanned(date0, date1);  // = 1
