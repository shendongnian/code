    bool continue = true;
    int rate = 1;
    dateTime dueTime = dateTime.Now.AddMilliSeconds(rate);
    
    while(continue){
      if(dateTime.Now >= dueTime){
        //do your thing.
        dueTime = DateTime.Now.AddMilliSeconds(rate);
      }
      else { 
        Thread.Sleep(1); 
      }
    }
