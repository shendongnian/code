    using System.Globalization; // For CultureInfo & DateTimeStyles    
    class MyClass
    {
        private bool IsValidDateFormatString(string userSuppliedFormat)
        {
            CultureInfo enUS = new CultureInfo("en-US");
            DateTime testDate = new DateTime(2009, 10, 1, 12, 0, 0); // Noon on Oct 1st 2009
            bool result;
        
            result = DateTime.TryParseExact(userSuppliedFormat, enUS, DateTimeStyles.None, testDate);
        
            return result;
            
        }    
    }
