    for (int i = 0; i < 4; i++)
    {
       myCounters[0].Increment();
    }
    for (int i = 0; i < 9; i++)
    {
       myCounters[1].Increment();
    }
    MainClass.PrintCounters(myCounters); //this is static
    myCounters[2].Reset();
    MainClass.PrintCounters(myCounters);
