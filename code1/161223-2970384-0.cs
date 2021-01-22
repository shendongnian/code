    if T2e > T1e {
    TimeSpan diff = new TimeSpan(endDate1.Ticks - startDate2.Ticks); 
    }
    else{
    TimeSpan diff = new TimeSpan(endDate2.Ticks - startDate2.Ticks); 
    }
    double daysDiff = diff.TotalDays; 
