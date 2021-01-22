    public void LoopAge(DateTime myDOB, DateTime FutureDate)
    {
        int years = 0;
        int months = 0;
        int days = 0;
        DateTime tmpMyDOB = new DateTime(myDOB.Year, myDOB.Month, 1);
        DateTime tmpFutureDate = new DateTime(FutureDate.Year, FutureDate.Month, 1);
        while (tmpMyDOB.AddYears(years).AddMonths(months) < tmpFutureDate)
        {
            months++;
            if (months > 12)
            {
                years++;
                months = months - 12;
            }
        }
        if (FutureDate.Day >= myDOB.Day)
        {
            days = days + FutureDate.Day - myDOB.Day;
        }
        else
        {
            months--;
            if (months < 0)
            {
                years--;
                months = months + 12;
            }
            days +=
                DateTime.DaysInMonth(
                    FutureDate.AddMonths(-1).Year, FutureDate.AddMonths(-1).Month
                ) + FutureDate.Day - myDOB.Day;
        }
        //add an extra day if the dob is a leap day
        if (DateTime.IsLeapYear(myDOB.Year) && myDOB.Month == 2 && myDOB.Day == 29)
        {
            //but only if the future date is less than 1st March
            if (FutureDate >= new DateTime(FutureDate.Year, 3, 1))
                days++;
        }
        
    }
