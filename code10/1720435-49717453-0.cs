    DaysOfWeek = DaysOfTheWeek.Monday | DaysOfTheWeek.Sunday;
    
    foreach (int day in Enum.GetValues(typeof(DaysOfTheWeek)))
    {
        if ( day & DaysOfWeek ) {
            /* do something for this day */
        }
    }
 
