    Use this code:
    
    DateTime? Startdate = cStartDate.GetValue<DateTime>().Date;
    DateTime? Enddate = cEndDate.GetValue<DateTime>().Date;
    TimeSpan diff =  Enddate.GetValue<DateTime>()- Startdate.GetValue<DateTime>() ;
    txtDayNo.Text = diff.Days.GetValue<string>();
