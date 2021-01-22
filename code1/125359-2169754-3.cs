    List<DayOfWeek> partyDays = new List<DayOfWeek> {
    	DayOfWeek.Saturday, DayOfWeek.Sunday
    };
    
    if (partyDays.Contains(MYWorkDay.DayOfWeek))
    	Party();
    else
    	IGottaWork();
