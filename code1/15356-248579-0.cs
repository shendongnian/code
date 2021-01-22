    private System.Int32 CountDaysOfWeek(System.DayOfWeek dayOfWeek, System.DateTime date1, System.DateTime date2)
    {
      System.DateTime EndDate;
      System.DateTime StartDate;
    
      if (date1 > date2)
      {
        StartDate = date2;
        EndDate = date1;
      }
      else
      {
        StartDate = date1;
        EndDate = date2;
      }
    
      while (StartDate.DayOfWeek != dayOfWeek)
        StartDate = StartDate.AddDays(1);
    
      return EndDate.Subtract(StartDate).Days / 7 + 1;
    }
