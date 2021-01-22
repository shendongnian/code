    /// <summary>
    /// Convert a .net date format to jQuery
    /// </summary>
    /// <param name="sFormat"></param>
    /// <returns></returns>
    private string ConvertDateFormatToJQuery(string sFormat)
    {
        if (string.IsNullOrEmpty(sFormat))
        {
            return null;
        }
    
        StringBuilder sbOutput = new StringBuilder("");
        string sDatePartChars = "dDmMyY";
    
        char cLast = sFormat[0];
        StringBuilder sbDatePart = new StringBuilder("");
    
        //Loop through char by char, extracting each date part or whitespace/seperator into individual components, and convert each component as we go
        foreach (char c in sFormat)
        {
            //Whitespace, or seperator
            if (sDatePartChars.IndexOf(c) == -1)
            {
                //If there is a currently extracted date part, convert
                sbOutput.Append(ConvertDatePartToJQuery(sbDatePart.ToString()));
                sbDatePart.Clear();
    
                //Whitespace or serator, just append to output
                sbOutput.Append(c.ToString());
    
                cLast = c;
            }
            else if (c.Equals(cLast))
            {
                //Same date part, extract it
                sbDatePart.Append(c.ToString());
            }
            else
            {
                //We've come to the beginning of a new date part, convert the currently extracted date part
                sbOutput.Append(ConvertDatePartToJQuery(sbDatePart.ToString()));
    
                sbDatePart.Clear();
                sbDatePart.Append(c.ToString());
                cLast = c;
            }
        }
        //Convert any remaining date part
        sbOutput.Append(ConvertDatePartToJQuery(sbDatePart.ToString()));
        return sbOutput.ToString();
    }
    
    /// <summary>
    /// Converts a date part (month,day,year) to JQuery format.  Unrecongized formats will just pass through
    /// </summary>
    /// <param name="sDatePart"></param>
    /// <returns></returns>
    private string ConvertDatePartToJQuery(string sDatePart)
    {
        //=======================================================================   
        // Handle:   
        //  C#     jQuery  Meaning   
        //  d      d       Day of month (no leading 0)  
        //  dd     dd      Day of month (leading 0)   
        //  ddd    D       Day name short
        //  dddd   DD      Day name long
        //  M      m       Month of year (no leading 0)   
        //  MM     mm      Month of year (leading 0)   
        //  MMM    M       Month name short
        //  MMMM   MM      Month name long
        //  yy     y       Two digit year   
        //  yyyy   yy      Four digit year 
        //======================================================================= 
    
        string sJQueryDatePart = "";
        //We've come to the beginning of a new date part, convert the currently extracted date part
        if (!string.IsNullOrEmpty(sDatePart))
        {
            if (sDatePart[0] == 'M')
            {
                if (sDatePart.Length == 1) //Month, no leading 0
                {
                    sJQueryDatePart = "m";
                }
                else if (sDatePart.Length == 2) //Month, leading 0
                {
                    sJQueryDatePart = "mm";
                }
                else if (sDatePart.Length == 3) //Month, short name
                {
                    sJQueryDatePart = "M";
                }
                else if (sDatePart.Length == 4) //Month, long name
                {
                    sJQueryDatePart = "MM";
                }
                else
                {
                    //invalid, just leave it
                    sJQueryDatePart = sDatePart;
                }
            }
            else if (sDatePart[0] == 'd')
            {
                if (sDatePart.Length == 1) //Day, no leading 0
                {
                    sJQueryDatePart = "d";
                }
                else if (sDatePart.Length == 2) //Day, leading 0
                {
                    sJQueryDatePart = "dd";
                }
                else if (sDatePart.Length == 3) //Day, short name
                {
                    sJQueryDatePart = "D";
                }
                else if (sDatePart.Length == 4) //Day, long name
                {
                    sJQueryDatePart = "DD";
                }
                else
                {
                    //invalid, just leave it
                    sJQueryDatePart = sDatePart;
                }
            }
            else if (sDatePart[0] == 'y')
            {
                if (sDatePart.Length <= 2) //Year, two digit
                {
                    sJQueryDatePart = "y";
                }
                else if (sDatePart.Length > 2) //Year four digit
                {
                    sJQueryDatePart = "yy";
                }
                else
                {
                    //invalid, just leave it
                    sJQueryDatePart = sDatePart;
                }
            }
            else
            {
                //invalid, just leave it
                sJQueryDatePart = sDatePart;
            }
        }
        return sJQueryDatePart;
    }
