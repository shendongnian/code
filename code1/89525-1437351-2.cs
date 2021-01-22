    /// <summary>
    /// Gets the date.
    /// </summary>
    /// <param name="date">The date: 05/07/2009</param>
    /// <returns></returns>
    private static DateTime GetDate(string date)
    {
        DateTime postDate = DateTime.Parse(date);        
        return postDate.Add(DateTime.UtcNow.TimeOfDay);        
    }
