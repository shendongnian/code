           Button_Click()
           {  
               Task workerTask = Task.Factory.StartNew(
               () =>
               {
                   DoWorkDelegate();
               }
               , CancellationToken.None
               , TaskCreationOptions.None
               , TaskScheduler.FromCurrentSynchronizationContext()
               ); 
    
               workerTask.wait();
           }
  
           void DoWorkDelegate()
           {
            _Mycallback.DoSomething();     // This works 
           }
