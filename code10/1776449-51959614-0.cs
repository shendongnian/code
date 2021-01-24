    Class A
    {
      private DispatcherTimer _timer; // This is a global variable
      public void StartTime(bool what)
      {
       DispatcherTimer timer = new Dispatcher(); //This is a local variable
       ...
      }
    }
