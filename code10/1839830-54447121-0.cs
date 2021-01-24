    public bool WindowIsActive()
    {
       foreach (var window in _scheduleWindows)
       {
          if (DateTime.Now >= window.StartTime && DateTime.Now <= window.EndTime)
          {
              return true;
          }
       }
    }
