    StopWatch s = StopWatch.StartNew();
    int timeInterval = 500; // for 0.5 second
    i=1;
    while(1)
    {
        if((int)s.ElapsedMilliseconds / timeInterval < i++ )
            continue;
        if(isIncrement)
        {
            //increment value
        }
        else
        {
            s.Stop();
            return;
        }
    }
