    private volatile bool _isBusy;
    private static Sample _lastSample;
    private Sample DoSomething()
    {
         lock(_lastSample)
         {
           if(_isBusy)
              return _lastSample;
           _isBusy = true;
         }
         try
         {
           _lastSample = new sameple//do something
         }
         finally
         {
            lock(_lastSample)
            {
               _isBusy = false;
            }
         }
         return _lastSample;
    } 
