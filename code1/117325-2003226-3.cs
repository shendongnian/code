    public DateTime ParseInThisYearOrNextYear(string s, out DateTime dt)
    {
        if (!Parse(s, "dddd MM dd", out dt))
        {
            if (!Parse(s + " " + DateTime.Now.Year + 1, "dddd MM dd yyyy", out dt))
            {
                throw new FormatException();
            }
        }
        return dt;
    }
    bool Parse(string s, string format, out DateTime dt)
    {
        return DateTime.TryParseExact(
            s,
            format,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out dt
        );
    }
