    for (DateTime date = startdate; date <= enddate; date = date.AddDays(1))
    {
        if (date.DayOfWeek == DayOfWeek.Wednesday || date.DayOfWeek == DayOfWeek.Thursday)
        {
            // skip to next day
            continue;
        }
    
        try 
        {
            // write to database
        }
        catch (Exception)
        {
            Console.Write("not entered");
            //lblError.Text = ex.Message;
        }
    }
