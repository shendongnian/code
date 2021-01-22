    public static int GetNetworkDays(DateTime startDate, DateTime endDate,out int totalWeekenDays, DayOfWeek[] weekendDays = null)
    {
        if (startDate >= endDate)
        {
            throw new Exception("start date can not be greater then or equel to end date");
        }
    
        DayOfWeek[] weekends = new DayOfWeek[] { DayOfWeek.Sunday, DayOfWeek.Saturday };
        if (weekendDays != null)
        {
            weekends = weekendDays;
        }
    
        var totaldays = (endDate - startDate).TotalDays + 1; // add one to include the first day to
        var counter = 0;
        var workdaysCounter = 0;
        var weekendsCounter = 0;
    
        for (int i = 0; i < totaldays; i++)
        {
    
            if (weekends.Contains(startDate.AddDays(counter).DayOfWeek))
            {
                weekendsCounter++;
            }
            else
            {
                workdaysCounter++;
            }
    
            counter++;
        }
    
        totalWeekenDays = weekendsCounter;
        return workdaysCounter;
    }
