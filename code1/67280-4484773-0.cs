    EventQuery query = new EventQuery();
    query.Uri = new Uri("https://www.google.com/calendar/feeds/" + this.Service.Credentials.Username + "/private/full");
    query.ExtraParameters = "orderby=starttime&sortorder=ascending";
    query.SingleEvents = true;
    query.StartTime = DateTime.Now;
    query.EndTime = DateTime.Now.AddDays(7.0);
    EventFeed calFeed = this.Service.Query(query);
    List<SyndicationItem> items = new List<SyndicationItem>();
    foreach (var entry in calFeed.Entries)
    {
       EventEntry eventEntry = entry as Google.GData.Calendar.EventEntry;
       if (eventEntry != null)
       {
          if (eventEntry.Times.Count != 0)
          {
             DateTime dt = eventEntry.Times[0].StartTime;
        }
    }
