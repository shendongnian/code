       public class EventsLogic
       { 
           private readonly IEventDAL ievtDal;
           public IEventDAL IEventDAL { get { return ievtDal; } }
           public EventsLogic(): this(null) {}
           public EventsLogic(IIEEWSDAL wsDal, IEventDAL evtDal)
           {
              ievtDal = evtDal ?? new EventDAL();
           }
        }
