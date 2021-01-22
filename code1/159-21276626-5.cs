    private int GetAge(DateTime dob) //This method will get the age in years
    {
        DateTime nowdate = DateTime.Now;
        TimeSpan ts = nowdate - dob;
        return (int)((decimal)ts.Days / 365.25); //The .25 is to account for the extra day in a leap year
    }    
    private string ValidateDate(DateTime dob) //This method will validate the date
    {
        int Years = GetAge(dob);
        if (Years < 18)
            message =  Years + " is too young. Please try again on your 18th birthday.";
        else if (Years >= 65)
            message = Years + " is too old. Date of Birth must not be 65 or older.";
        else
            return null; //Denotes validation passed
    }
