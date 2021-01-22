    /// <summary>
    /// Sometimes the date from Excel is a string, other times it is an OA Date:
    /// Excel stores date values as a Double representing the number of days from January 1, 1900.
    /// Need to use the FromOADate method which takes a Double and converts to a Date.
    /// OA = OLE Automation compatible.
    /// </summary>
    /// <param name="date">a string to parse into a date</param>
    /// <returns>a DateTime value; if the string could not be parsed, returns DateTime.MinValue</returns>
    public static DateTime ParseExcelDate( this string date )
    {
        DateTime dt;
        if( DateTime.TryParse( date, out dt ) )
        {
            return dt;
        }
    
        double oaDate;
        if( double.TryParse( date, out oaDate ) )
        {
            return DateTime.FromOADate( oaDate );
        }
    
        return DateTime.MinValue;
    }
