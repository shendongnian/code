    private static object lockHolder = new object();
    if (ActionIsValid()) {
      lock(lockHolder) {
        if (ActionIsValid()) {
           DoSomething();    
        }
      }
    }
    
    
