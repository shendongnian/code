    public List<Meeting> GetMeetings(MeetingOptions options) {
        CalendarService service = AuthenticateAccount(CalendarId);
        var extendedProperty = new List<String>();
        if (options.userId != null)
            extendedProperty.Add("UserId=" + options.userId);
        
        if (options.classroomId.HasValue)
            extendedProperty.Add("classroomId=" + options.classroomId);
        
        EventsResource.ListRequest request = new EventsResource.ListRequest(service, CalendarId) {
            TimeMin = options.timeMin,
            TimeMax = options.timeMax,
            TimeZone = "Europe/Amsterdam",
            PrivateExtendedProperty = extendedProperty.ToArray()
        };
        Events events = request.Execute();
        foreach (var item in eventList) {
            //....
        }
    }
    
