    public List<Meeting> GetMeetings(DateTime minTime, DateTime maxTime, 
                                     string userId = null, int? classroomId = null)
    {
        CalendarService service = AuthenticateAccount(CalendarId);
        var extProp = new List<String>();
        if (userId != null) {
            extProp.Add("UserId=" + userId);
        }
        if (classroomId.HasValue) {
            extProp.Add("classroomId=" + classroomId);
        }
        //  Optional: Throw exception if extProp is empty
        EventsResource.ListRequest request = new EventsResource.ListRequest(service, CalendarId)
        {
            TimeMin = timeMin,
            TimeMax = timeMax,
            TimeZone = "Europe/Amsterdam",
            PrivateExtendedProperty = extProp.ToArray()
        };
