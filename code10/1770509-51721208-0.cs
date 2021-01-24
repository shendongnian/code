    if (events.Items != null && events.Items.Count > 0)
    {
        var overlaplist = events.Items.Where(e => (Convert.ToDateTime(e.Start.DateTime) < eventi && Convert.ToDateTime(e.End.DateTime) > eventi.AddMinutes(60))
            || (Convert.ToDateTime(e.Start.DateTime) < eventi && Convert.ToDateTime(e.End.DateTime) > eventi)
            || (Convert.ToDateTime(e.Start.DateTime) > eventi && Convert.ToDateTime(e.Start.DateTime) < eventi.AddMinutes(60))
            || (Convert.ToDateTime(e.End.DateTime) > eventi && Convert.ToDateTime(e.End.DateTime) < eventi.AddMinutes(60))).ToList();
    
        if (overlaplist.Count() > 0)
        {
            foreach (var eventItem in overlaplist)
            {
                Console.WriteLine("Date range of your new event overlaps with {0}, which start at {1} and end at {2})", eventItem.Summary, eventItem.Start.DateTime, eventItem.End.DateTime);
            }
        }
        else
        {
            Console.WriteLine("Your new event is available!");
        }
    
    }
    else
    {
        Console.WriteLine("No upcoming events found.");
    }
