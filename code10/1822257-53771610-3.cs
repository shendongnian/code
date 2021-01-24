    //Fake view model
    public class CalendarEventViewModelMapper : IMapper<CalendarEvent, CalendarEventViewModel>
    {
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
    }
  
    public interface IMapper<in TIn, out TOut>
    {
            TOut Map(TIn model);
    }
    public class CalendarEventViewModelMapper : IMapper<CalendarEvent, CalendarEventViewModel>
    {
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
    }
            
        public ValuesController( IMapper<CalendarEvent, CalendarEventViewModel> calendarMapper)
        {
            _calendarMapper = calendarMapper;
        }
 
        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var calendarEvent = GetMyCalendarEventFromDB(id);
            return this.Ok(_calendarMapper.Map(calendarEvent));
        }
        private CalendarEvent GetMyCalendarEventFromDB(int id)
        {
            return new CalendarEvent("yyyy-dd-MM")
            {
                EndDateTimeUtc = DateTime.UtcNow.AddHours(3),
                EventId = id,
                IsApproved = true,
                StartDateTimeUtc = DateTime.UtcNow.AddHours(2),
                Summary = "My magical Event",
                TimeZoneId = "UTC",
                Title = "Magical Event"
            };
        }
    }
