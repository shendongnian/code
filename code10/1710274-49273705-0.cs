    query = query.Where(d => 
        DateInRangeFormat(d.Date) >= DateInRangeFormat(startDate.Date)
        && DateInRangeFormat(d.Date) <= DateInRangeFormat(endDate.Date))
        .AsQuerybable();
    // accepts date in MM.DD.YYYY format and returns YYYYMMDD
    public static string DateInRangeFormat(string date)
    {
        return date.SubString(6) + date.SubString(0, 2) + date.SubString(3, 2);
    }
