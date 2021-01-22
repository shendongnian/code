    public void DoSomething(DaysOfWeek day)
    {
      if ((day & DaysOfWeek.Mon) == DaysOfWeek.Mon) // Does a bitwise and then compares it to Mondays enum value
      {
        // Monday was passed in
      }
    }
  
