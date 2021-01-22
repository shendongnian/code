    // Create list to hold enum values
    List<string> WorkingDaysList = new List<string>();
    
    // loop thru enum values and store in List
    foreach (var value in Enum.GetValues(typeof(WorkingDays)))
    {
        var _WorkingDaysList = ((WorkingDays)value).ToString();
        WorkingDaysList.Add(_WorkingDaysList);
    }
    // use linq to query list       
    var result = (from d in WorkingDaysList where d.ToLower() == input.ToLower() select d).FirstOrDefault();
