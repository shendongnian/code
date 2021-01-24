    Class Test
    {
         private readonly IMyService _myService;
         private static readonly SemaphoreSlim _defaultsMutex = new SemaphoreSlim(1, 1);
         public Test(IMyService myService)
         {
              _myService = myService;
         }
      
    
         public async Task FireMutexMethod()
         {
    
              await _defaultsMutex.WaitAsync();
              try 
              {
                  //do some work
              }
              finally
              {
                    _defaultsMutex.Release();
              }
    
         }
    }
