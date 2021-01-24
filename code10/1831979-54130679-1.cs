    List<EventModel> events = GetAllEvents();
    
    List<EventModel> openEvents = new List<EventModel>();
    List<EventModel> closedEvents = new List<EventModel>();
    
    events.ForEach(x => (x.Closer_User_ID == null ? openEvents : closedEvents).Add(x));
