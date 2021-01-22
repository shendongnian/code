    [Flags]
    enum DaysOfWeek
    {
       None = 0x00,
       Sunday = 0x01,
       Monday = 0x02,
       Tuesday = 0x04,
       Wednesday = 0x08,
       Thursday = 0x10,
       Friday = 0x20,
       Saturday = 0x40,
       // Some more possibilities
       Weekend = Saturday | Sunday,
       Weekday = Monday | Tuesday | Wednesday | Thursday | Friday,
    }
    public void RunOnDays(DaysOfWeek days)
    {
       bool isTuesdaySet = (days & DaysOfWeek.Tuesday) == DaysOfWeek.Tuesday;
       if (isTuesdaySet)
          //...
       // Do your work here..
    }
    public void CallMethodWithTuesdayAndThursday()
    {
        this.RunOnDays(DaysOfWeek.Tuesday | DaysOfWeek.Thursday);
    }
