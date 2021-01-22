    public void GetAge(DateTime dob, DateTime now, out int years, out int months, out int days)
    {
        years = 0;
        months = 0;
        days = 0;
    
        DateTime tmpdob = new DateTime(dob.Year, dob.Month, 1);
        DateTime tmpnow = new DateTime(now.Year, now.Month, 1);
    
        while (tmpdob.AddYears(years).AddMonths(months) < tmpnow)
        {
            months++;
            if (months > 12)
            {
                years++;
                months = months - 12;
            }
        }
    
        if (now.Day >= dob.Day)
            days = days + now.Day - dob.Day;
        else
        {
            months--;
            if (months < 0)
            {
                years--;
                months = months + 12;
            }
            days += DateTime.DaysInMonth(now.AddMonths(-1).Year, now.AddMonths(-1).Month) + now.Day - dob.Day;
        }
    
        if (DateTime.IsLeapYear(dob.Year) && dob.Month == 2 && dob.Day == 29 && now >= new DateTime(now.Year, 3, 1))
            days++;
    
    }   
    private string ValidateDate(DateTime dob) //This method will validate the date
    {
        int Years = 0; int Months = 0; int Days = 0;
        
        GetAge(dob, DateTime.Now, out Years, out Months, out Days);
        if (Years < 18)
            message =  Years + " is too young. Please try again on your 18th birthday.";
        else if (Years >= 65)
            message = Years + " is too old. Date of Birth must not be 65 or older.";
        else
            return null; //Denotes validation passed
    }
