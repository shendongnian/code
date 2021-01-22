    public class Base
    {
       private void Initialize()
       {
          // do whatever necessary to initialize
       }
       public void UseMe()
       {
          if (!_initialized) Initialize();
          // do work
       }
    }
