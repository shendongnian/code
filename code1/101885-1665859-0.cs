    public DateTime FirstDayOfWeek(DateTime date)
    {
        var candidateDate=date;
        while(candidateDate.DayOfWeek!=DayOfWeek.Monday) {
            candidateDate=candidateDate.AddDays(-1);
        }
        return candidateDate;
    }
