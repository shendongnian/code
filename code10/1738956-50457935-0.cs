    DateTimeFormatInfo formatInfo = DateTimeFormatInfo.CurrentInfo;
    IEnumerable<PropertyInfo> patternProperties = formatInfo.GetType().GetProperties()
        .Where(property => property.Name.EndsWith("Pattern"));
    foreach (PropertyInfo patternProperty in patternProperties)
    {
        string pattern = (string) patternProperty.GetValue(formatInfo);
        bool wasParsed = DateTime.TryParseExact(dateString, pattern, formatInfo, DateTimeStyles.None, out DateTime _);
        Console.WriteLine($"{patternProperty.Name} (\"{pattern}\"): {wasParsed}");
    }
