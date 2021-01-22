    void onTimerTick()
    {
       if (EventQueue.Any() && EventQueue.First().StartTime >= DateTime.Now)
       {
          Event e = EventQueue.Dequeue();
          e.Method;
       }
    }
