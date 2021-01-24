        Event myEvent = new Event
            {
                Summary = "Discussion on new project",
                Location = "Mentor",
                Start = new EventDateTime()
                {
                    DateTime = new DateTime(2018, 8, 16, 10, 0, 0),
                    TimeZone = "America/Los_Angeles"
                },
                End = new EventDateTime()
                {
                    DateTime = new DateTime(2018, 8, 16, 11, 30, 0),
                    TimeZone = "America/Los_Angeles"
                },
                Recurrence = new String[] { "RRULE:FREQ=WEEKLY;BYDAY=MO"},
                Attendees = new List<EventAttendee>()
      {
        new EventAttendee() { Email = "abc@gmail.com" }
      }
            };
     var recurringEvent = service.Events.Insert(myEvent, "primary");
            recurringEvent.SendNotifications = true;
            recurringEvent.Execute();
