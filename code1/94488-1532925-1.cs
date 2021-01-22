    using System.Globalization;
    public static class MyClass
    {
        private bool IsValidDateFormat(this Date value)
        {
            CultureInfo enUS = new CultureInfo("en-US");
            DateTime testDate = new DateTime(2009, 10, 1, 12, 0, 0); // Noon on Oct 1st 2009
            bool result;
        
            result = DateTime.TryParseExact(value, enUS, DateTimeStyles.None, testDate);
            return result;        
        }    
    }
