    private volatile bool _isBusy;
    private object _syncObj = new object();
    private void DoSomething()
    {
         lock(_syncObj)
         {
           if(_isBusy)
              return;
           _isBusy = true;
         }
         try
         {
            //do something
         }
         finally
         {
            lock(_syncObj)
            {
               _isBusy = false;
            }
         }
    } 
