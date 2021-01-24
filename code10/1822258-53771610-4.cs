    //Fake view model
    public class CalendarEventViewModel
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public DateTime? StartDateTimeUtc { get; set; }
        public DateTime? EndDateTimeUtc { get; set; }
        public string Summary { get; set; }
        public bool IsApproved { get; set; }
        public string TimeZoneId { get; set; }
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
        
    [Route("api/Values")]
    public class ValuesController 
    { 
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
    }
