    volatile data live;
    
    void Thread1()
    {
      
      if (live.Field1)
      {
        Console.WriteLine(live.Field1);
      }
    }
