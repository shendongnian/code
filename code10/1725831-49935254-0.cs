    public string[] getDateRange(string dateRange)
    {
         string[] dateSplit = dateRange.Split(new string[] { "to" }, StringSplitOptions.RemoveEmptyEntries);
         return new string[]{ dateSplit[0], dateSplit[1]};
    }
