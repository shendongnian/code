    for(DateTime date = StartDate; date.Date <= EndDate.Date; date = date.AddDays(1))
    {
       ...
       if (EndDate.Date == DateTime.MaxValue.Date)
       {
           break;
       }
    }
