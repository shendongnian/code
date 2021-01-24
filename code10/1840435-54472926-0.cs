    // example to convert text box value to 'DateTime' instance
    // if you have specific format, better to use DateTime.ParseExact or DateTime.TryParseExact
    DateTime endDate = Convert.ToDateTime(endDateTb.Value); // or endDateTb.Text property
    
    // compare both dates
    if (DateTime.Today > endDate)
    {
        // execute delete query here
    }
