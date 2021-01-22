    //suspect thread
    foreach(var thing in whatever)
    {
        //do some stuff
        SomeClass.StaticVariable = DateTime.Now;
    }
    //monitor thread
    while(shouldStillBeWorking)
    {
        Thread.Sleep(TimeSpan.FromMinutes(10));
        if (DateTime.Now.Subtract(TimeSpan.FromMinutes(15) < SomeClass.StaticVariable)
            suspectThread.Abort()
    }
