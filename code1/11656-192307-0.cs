    public DateTime getDeadline(SubmitTime, ProjectTimeAllowed)
    {
       if (SubmitTime+ProjectTimeAllowed >= DayEndTime)
               return getDeadline(NextDayStart, ProjectTimeAllowed-DayEndTime-SubmitTime)
       else
               return SubmitTime + ProjectTimeAllowed
    }
