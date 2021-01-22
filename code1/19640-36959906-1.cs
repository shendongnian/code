    try
    {
      HourGlass.ApplicationEnabled = true;
      //time consuming synchronous task
    }
    finally
    {
      HourGlass.ApplicationEnabled = false;
    }
