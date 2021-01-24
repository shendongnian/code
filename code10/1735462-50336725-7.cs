    public List<Meeting> GetMeetings(MeetingOptions options) {
        CalendarService service = AuthenticateAccount(CalendarId);
        string[] extendedProperty = buildExtendedProperty(options);
        EventsResource.ListRequest request = new EventsResource.ListRequest(service, CalendarId) {
            TimeMin = options.timeMin,
            TimeMax = options.timeMax,
            TimeZone = "Europe/Amsterdam",
            PrivateExtendedProperty = extendedProperty,
        };
        Events events = request.Execute();
        foreach (var item in eventList) {
            //....
        }
    }
    
    
