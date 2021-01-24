    public static List<DateTime?> getDateRange(string dateRange)
    {
        var selectedDates = new List<DateTime?>();
        string[] dateSplit = dateRange.Split(new string[] { "to" }, StringSplitOptions.RemoveEmptyEntries);
        for (var date = Convert.ToDateTime(dateSplit[0].Trim());
                date <= Convert.ToDateTime(dateSplit[1].Trim());
                date = date.AddDays(1))
        {
            selectedDates.Add(date);
        }
        foreach (var date in selectedDates)
        {
            Console.WriteLine(date.Value.ToString("dd/MM/yyyy"));
        }
    
        return selectedDates;
    }
