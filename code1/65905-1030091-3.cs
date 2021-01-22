    [Flags]
    enum DaysOfWeek
    {
       Sunday = 1,
       Monday = 2,
       Tuesday = 4,
       Wednesday = 8,
       Thursday = 16,
       Friday = 32,
       Saturday = 64
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
