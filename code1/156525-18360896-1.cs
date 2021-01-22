    Console.CancelKeyPress += delegate(object sender, ConsoleCancelEventArgs e)
    {
      if (e.SpecialKey == ConsoleSpecialKey.ControlC)
      {
        e.Cancel = true; // tell the CLR to keep running
      }
      else if (e.SpecialKey == ConsoleSpecialKey.ControlBreak)
      {
        //e.Cancel = true; // "Applications are not allowed to cancel the ....
      }
      // do whatever you must to inform threads on application exit, etc
    }
