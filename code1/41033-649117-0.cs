    class Event
    {
       public DateTime StartTime { get; set; }
       public Action Method { get; set; }
       public Event(Action method)
       {
          Method = method;
          StartTime = DateTime.Now + TimeSpan.FromSeconds(1);
       }
    }
