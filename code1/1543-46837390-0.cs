    //set a couple of variables for demo purposes
    DateTime IcsDateStart = DateTime.Now.AddDays(2);
    DateTime IcsDateEnd = IcsDateStart.AddMinutes(90);
    string IcsSummary = "ASP.Net demo snippet";
    string IcsLocation = "Amsterdam (Netherlands)";
    string IcsDescription = @"This snippes show you how to create a calendar item file (.ics) in ASP.NET.\nMay it be useful for you.";
    string IcsFileName = "MyCalendarFile";
    
    //create a new stringbuilder instance
    StringBuilder sb = new StringBuilder();
    
    //begin the calendar item
    sb.AppendLine("BEGIN:VCALENDAR");
    sb.AppendLine("VERSION:2.0");
    sb.AppendLine("PRODID:stackoverflow.com");
    sb.AppendLine("CALSCALE:GREGORIAN");
    sb.AppendLine("METHOD:PUBLISH");
    
    //create a custom time zone if needed, TZID to be used in the event itself
    sb.AppendLine("BEGIN:VTIMEZONE");
    sb.AppendLine("TZID:Europe/Amsterdam");
    sb.AppendLine("BEGIN:STANDARD");
    sb.AppendLine("TZOFFSETTO:+0100");
    sb.AppendLine("TZOFFSETFROM:+0100");
    sb.AppendLine("END:STANDARD");
    sb.AppendLine("END:VTIMEZONE");
    
    //add the event
    sb.AppendLine("BEGIN:VEVENT");
    
    //with a time zone specified
    sb.AppendLine("DTSTART;TZID=Europe/Amsterdam:" + IcsDateStart.ToString("yyyyMMddTHHmm00"));
    sb.AppendLine("DTEND;TZID=Europe/Amsterdam:" + IcsDateEnd.ToString("yyyyMMddTHHmm00"));
    
    //or without a time zone
    //sb.AppendLine("DTSTART:" + IcsDateStart.ToString("yyyyMMddTHHmm00"));
    //sb.AppendLine("DTEND:" + IcsDateEnd.ToString("yyyyMMddTHHmm00"));
    
    //contents of the calendar item
    sb.AppendLine("SUMMARY:" + IcsSummary + "");
    sb.AppendLine("LOCATION:" + IcsLocation + "");
    sb.AppendLine("DESCRIPTION:" + IcsDescription + "");
    sb.AppendLine("PRIORITY:3");
    sb.AppendLine("END:VEVENT");
    
    //close calendar item
    sb.AppendLine("END:VCALENDAR");
    
    //create a string from the stringbuilder
    string CalendarItemAsString = sb.ToString();
    
    //send the ics file to the browser
    Response.ClearHeaders();
    Response.Clear();
    Response.Buffer = true;
    Response.ContentType = "text/calendar";
    Response.AddHeader("content-length", CalendarItemAsString.Length.ToString());
    Response.AddHeader("content-disposition", "attachment; filename=\"" + IcsFileName + ".ics\"");
    Response.Write(CalendarItemAsString);
    Response.Flush();
    HttpContext.Current.ApplicationInstance.CompleteRequest();
