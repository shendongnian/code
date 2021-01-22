    public static class Month
    {
        public static int ToInt(this string month)
        {
            return Array.IndexOf(
                CultureInfo.CurrentCulture.DateTimeFormat.MonthNames,
                month.ToLower(CultureInfo.CurrentCulture))
                + 1;
        }
    }
