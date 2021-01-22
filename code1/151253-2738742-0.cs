    public static DateTime CalcDate(string expression, DateTime epoch)
    {
        var match = System.Text.RegularExpressions.Regex.Match(expression, 
                        @"(([+-])(\d+)([YDM]))+");
        if (match.Success && match.Groups.Count >= 5)
        {
            var signs = match.Groups[2];
            var counts = match.Groups[3];
            var units = match.Groups[4];
            for (int i = 0; i < signs.Captures.Count; i++)
            {
                string sign = signs.Captures[i].Value;
                int count = int.Parse(counts.Captures[i].Value);
                string unit = units.Captures[i].Value;
                if (sign == "-") count *= -1;
                switch (unit)
                {
                    case "Y": epoch = epoch.AddYears(count); break;
                    case "M": epoch = epoch.AddMonths(count); break;
                    case "D": epoch = epoch.AddDays(count); break;
                }
            }
        }
        else
        {
            throw new FormatException(
                "The specified expression was not a valid date expression.");
        }
        return epoch;
    }
