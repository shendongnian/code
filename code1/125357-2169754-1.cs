        if (MYWorkDay.DayOfWeek != DateTime.DayOfWeek.Saturday
              && MYWorkDay.DayOfWeek != DateTime.DayOfWeek.Sunday) 
        {
            IGottaWork();
        }
        else
            Party();
