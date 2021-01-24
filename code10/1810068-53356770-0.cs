    public class Event 
    {
        public SubEventCollection SubEvents { get; private set; }
        public Event()
        {
             using ( var stream = new MemoryStream(DbSubEventsBucket) )
                 SubEvents = Serializer.Deserialize<SubEventCollection3>(stream);
             SubEvents.Initialize(this);
        }
    }
