     public decimal ParseDecimal(string input)
    {
        CultureInfo cultureInfo = null;
        NumberStyles style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
        decimal value = 0;
        string[] userLanguages = HttpContext.Current.Request.UserLanguages;
        if (userLanguages.Length > 0)
        {
            cultureInfo = new CultureInfo(userLanguages[0]);
            Decimal.TryParse(input, style, cultureInfo, out value);
        }
        return value;
    }
