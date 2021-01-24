    public class EventsController<TEvent> 
        : Controller
        where TEvent : IEvent 
    {
        private readonly IEnumerable<IEventHandler<TEvent>> _projectors;
        public EventsController(IEnumerable<IEventHandler<Event>> projectors)
        {
            _projectors = projectors;
        }
        
        [HttpPost()]
        public IActionResult AddEvent([FromBody]TEvent evt)
        {
            foreach (var projector in _projectors)
            {
                projector.Handle(evt);
            }
            return Ok();
        }
    }
