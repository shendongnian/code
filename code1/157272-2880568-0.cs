    delegate void EnumHandler (args);
    SortedDictionary <Enum, EnumHandler> handlers;
    constructor
    {
       handlers = new SortedDictionary <Enum, EnumHandler> ();
       fill in handlers
    }
    void SomeFunction (Enum enum)
    {
      EnumHandler handler;
      if (handlers.TryGetValue (enum, out handler))
      {
         handler (args);
      }
      else
      {
        // not handled, report an error
      }
    }
