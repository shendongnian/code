    const int DoNotWait = 0;
                              
    ManualResetEvent waitHandle = new ManualResetEvent(false);                   
    Console.WriteLine("Is set:{0}", waitHandle.WaitOne(DoNotWait));
             
    waitHandle.Set(); 
    Console.WriteLine("Is set:{0}", waitHandle.WaitOne(DoNotWait));   
