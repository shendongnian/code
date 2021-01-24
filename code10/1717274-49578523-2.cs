    public static string SSN(String propertyName, bool isRequired, bool allowDashFormat, bool allowNoDashFormat)
    
        {
           
     if ((String.IsNullOrWhiteSpace(propertyName))
                && (isRequired == true))
            {
                return "SSN required.";
            }
            if (!String.IsNullOrEmpty(propertyName)
                && (allowDashFormat && !regex.SSNDashes.IsMatch(propertyName)
                && (allowNoDashFormat && !regex.SSNNoDashes.IsMatch(propertyName))))
            {
                return "Invalid SSN.";
            }
            return null;
    
        }
    }
