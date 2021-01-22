    System.Threading.Timer timer = null;
    
    timer = new System.Threading.Timer((g) =>
      {
    	  Console.WriteLine(1); //do whatever
    
    	  timer.Change(5000, Timeout.Infinite);
      }, null, 0, Timeout.Infinite);
