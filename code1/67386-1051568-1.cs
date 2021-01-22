    Timer aTimer = new System.Threading.Timer(MyTask, null, 0, 10000);
    
    static void MyTask(object state)
    {
      ...
    }
