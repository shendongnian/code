    bool lockWasTaken = false;
    var temp = obj;
    try 
    { 
        Monitor.Enter(temp, ref lockWasTaken); 
        { 
           // body 
        }
    }
    finally 
    { 
        if (lockWasTaken) 
            Monitor.Exit(temp); 
    }
