    string convertDateToAcceptedFormat(string inputDate)
    {
        Regex patternDDMMYYYY = new Regex(@"^(\d\d\/){2}\d{4}$");
        if (patternDDMMYYYY.Match(inputDate).Success)
            return inputDate;
    
        Regex patternDMMYYYY = new Regex(@"^\d\/\d\d\/\d{4}$");
        if (patternDMMYYYY.Match(inputDate).Success)
            return "0" + inputDate;
    
        Regex patternDMYYYY = new Regex(@"^(\d\/){2}\d{4}$");
        if (patternDMYYYY.Match(inputDate).Success)
            return "0" + inputDate.Substring(0,2) + "0" + inputDate.Substring(2);
    
        throw new Exception("Input date doesn't match any pattern");
    }
