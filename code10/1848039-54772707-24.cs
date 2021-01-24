    using System;
    // ...
    public void DoSomething(Action callback)
    {
        // do something
        callback.Invoke();
    }
    
