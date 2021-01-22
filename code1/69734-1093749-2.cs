    const double DAILY_FINE = 0.25;
    var dueDate = DateTime.Parse("7/1/2009");
    var returnDate = DateTime.Parse("7/15/2009");
    double lateCharge = 0.0;
    if (dueDate < returnDate)
    {
        lateCharge = DAILY_FINE * DaysLate(dueDate, returnDate);
    }
    string msg = String.Format("Late charge = {0:C}", lateCharge);
    System.Diagnostics.Debug.WriteLine(msg);
