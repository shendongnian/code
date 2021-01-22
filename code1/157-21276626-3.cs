    private int GetAge(string dob) //This method will get the age in years
    {
        DateTime dobdate = DateTime.Parse(dob);
        DateTime nowdate = DateTime.Now;
        TimeSpan ts = nowdate - dobdate;
        return (int)((decimal)ts.Days / 365.25); //The .25 is to account for the extra day in a leap year
    }    
    private bool ValidateDate(string dob) //This method will validate the date
    {
        int Years = GetAge(dob);
        if (Years < 18)
        {
            message = "Date of Birth must not be less then 18";
            return false;
        }
        else if (Years > 65)
        {
            message = "Date of Birth must not be greater then 65";
            return false;
        }
        dobvalue = dob;
        return true;
    }
