    List<EventModel> openEvents = new List<EventModel>();
    List<EventModel> closedEvents = new List<EventModel>();
    
    foreach(var e in  events)
    {
      if(e.Closer_User_ID == null)
      {
    	openEvents.Add(e);
      }
      else
      {
    	closedEvents.Add(e);
      }
    }
