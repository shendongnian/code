    public static void Test()
    {
        var dateString = "29.7.2018";
        var cultureGermany = new CultureInfo("de-DE");
        var cultureUs = new CultureInfo("en-US");
        var germanSucceed = DateTime.TryParse(dateString, cultureGermany, DateTimeStyles.None, out var germanDateTime);
        var usSucceed = DateTime.TryParse(dateString, cultureUs, DateTimeStyles.None, out var usDateTime);
        var germanyResult = germanSucceed ? germanDateTime.ToString() : "Failed";
        var usResult = usSucceed ? usDateTime.ToString() : "Failed";
        Debug.WriteLine($"Germany: Succeeded: {germanSucceed}, value: {germanyResult}");
        Debug.WriteLine($"US: Succeeded: {usSucceed}, value: {usResult}");
    }
