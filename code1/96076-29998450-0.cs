    public void threadExample1()
    {
        Thread t1=new Thread(fun1);
        Thread t2=new Thread(fun2);
    
        t1.Start();
        t1.Join();
    
        t2.Start();
    }
     
In the second example, we don't know which thread will start first, but we know there is only one thread will run at a time because of lock
    public readonly object locker = new object();
    public void threadExample2()
    {
       Thread t1=new Thread(fun1);
       Thread t2=new Thread(fun2);
    
       t1.Start();
       t2.Start();
    }
    
    public void fun1()
    { 
       lock(locker)
       {
           for (int i = 0; i < 10; i++)
             Console.Write("1");
       }
    }
    public void fun2()
    { 
       lock(locker)
       {
           for (int i = 0; i < 10; i++)
             Console.Write("2");
       }
    }
