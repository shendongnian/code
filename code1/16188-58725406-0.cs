    using System.Globalization;
    
    ....
    
    string FullMonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.UtcNow.Month);
