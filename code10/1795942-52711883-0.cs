                string userEmail = "UserName@CompanyName.com";
                string calId = "AAMkAGIzZDM4OWI0LWN...….";
                ICalendarEventsCollectionPage events = client.Users[$"{userEmail}"]
                    .Calendars[$"{calId}"]
                    .Events.Request().GetAsync().Result;
