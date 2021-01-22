    struct Event 
    { 
      public string Description {get; set;} 
      public Severity Severity {get; set;}
    }
    
    interface Logger
    {
      void WriteEvent(Event e);
      void IEnumerable<Event> GetEvents();
    }
