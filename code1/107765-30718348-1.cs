    using System.Globalization; 
    
    ...
    decimal myValue = -0.123m;
    NumberFormatInfo percentageFormat = new NumberFormatInfo { PercentPositivePattern = 1, PercentNegativePattern = 1 };
    string formattedValue = myValue.ToString("P2", percentageFormat); // "-12.30%" (in en-us)
