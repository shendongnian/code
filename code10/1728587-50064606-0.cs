    public class EventsController 
        : Controller
    {
        private readonly IEnumerable<IEventHandler<EventA>> _Aprojectors;
        private readonly IEnumerable<IEventHandler<EventB>> _Bprojectors;
        public EventsController(IEnumerable<IEventHandler<EventA>> Aprojectors,
                                IEnumerable<IEventHandler<EventB>> Bprojectors)
        {
            _Aprojectors = Aprojectors;
            _Bprojectors = Bprojectors;
        }
        // ...
    }
