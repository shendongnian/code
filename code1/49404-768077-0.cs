    int inMyRandSeed;
    for(int i=0;i<100;i++)
    {
       inMyRandSeed = System.Environment.TickCount + i;
       .
       .
       .
       myNewObject = new MyNewObject(inMyRandSeed);  
       .
       .
       .
    }
