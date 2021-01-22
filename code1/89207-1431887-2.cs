    public class MySingletonClass
    {
      private readonly object _mySingletonLock = new object();
      private volatile MySingletonClass _mySingletonObj;
      private MySingletonClass()
      {
        // normal initialization, do not call Instance()
      }
    
      public static MySingletonClass Instance()
      {
        if (_mySingletonObj == null)
        {
          lock (_mySingletonLock)
          {
            if (_mySingletonObj  == null)
              _mySingletonObj = new MySingletonClass();
          }
        }
        return _mySingletonObj;
      }
    }
    
    MySingletonClass _myObj = MySingletonClass.Instance();
