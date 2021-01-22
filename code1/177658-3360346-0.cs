    void Thread1()
    {    
       for(;;)
       {
          lock (port)
          {
              port.Write("Hi 1");
          }
       }
    }
    void Thread2()
    {    
       for(;;)
       {
          lock (port)
          {
              port.Write("Hi 2");
          }
       }
    }
