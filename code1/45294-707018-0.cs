    if(lastTime = 0)
    {
        lastTime = Environment.TickCount;
        return;
    }
    int curTime = Environment.TickCount; // store this baby.
    int timeDiff = lastTime - curTime;
    if(timeDiff == 0)
       return;
    curAlt += (maxAlt - curAlt) * timeDiff / (150000); // TickCount reports
                                                       // time in Ticks
                                                       // (1000 ticks per second)
    lastTime = curTime;
