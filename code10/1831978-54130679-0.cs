    List<EventModel> events = GetAllEvents();
    
    List<EventModel> openEvents = events.Where(e => e.Closer_User_ID == null);
    List<EventModel> closedEvents = events.Where(e => e.Closer_User_ID != null);
    
    events.ForEach(x => (x.Closer_User_ID == null ? openEvents : closedEvents).Add(x));
