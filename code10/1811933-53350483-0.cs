    DateTime s1 = new DateTime(1990, 1, 1);
    TimeSpan ts1 = new TimeSpan();
    for (int i = 0; i < metroGrid1.Rows.Count; ++i)
    {
        ts1 += s1.AddDays(Convert.ToInt32(metroGrid1.Rows[i].Cells[2].Value)).AddMonths(Convert.ToInt32(metroGrid1.Rows[i].Cells[1].Value)).AddYears(Convert.ToInt32(metroGrid1.Rows[i].Cells[0].Value)) - s1;
    } 
    int daysResult;
    int monthsResult;
    int yearsResult;
    // get the total number of days, then /360 to get the years number;
    yearsResult = ts1.days /365;
    
    // get the month count by /30 from the remainder of /365;
    monthsResult = (ts1.days % 365) / 30;
    
    // get the day count from the remainder of /30;
    daysResult = (ts1.Days % 365) % 30;
    lbltotal.Text = "Total: " + yearsResult.ToString() + " years, " + monthsResult.ToString() + " months and " + daysResult.ToString() + " days";
