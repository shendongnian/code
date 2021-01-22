    [Flags]
    enum DaysOfWeek
    {
       Sunday,
       Monday,
       // ...
       Saturday
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
