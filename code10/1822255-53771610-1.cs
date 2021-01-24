        public CalendarEventViewModel Map(CalendarEvent model)
        {
            return new CalendarEventViewModel
            {
                EndDateTimeUtc = model.EndDateTimeUtc,
                EventId = model.EventId,
                IsApproved = model.IsApproved,
                StartDateTimeUtc = model.StartDateTimeUtc,
                Summary = model.Summary,
                TimeZoneId = model.TimeZoneId,
                Title = model.Title
            };
        }
    }`
            
