    TimerCallback aTask =  MyTask;
    Timer aTimer = new System.Threading.Timer( aTask, null, 0, 10000);
    
    static void MyTask(object state)
    {
      ...
    }
