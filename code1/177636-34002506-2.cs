    for(DateTime date = StartDate; date.Date <= EndDate.Date; date = date.AddDays(1))
    {
       ...
       if (date.Date == DateTime.MaxValue.Date)
       {
           break;
       }
    }
