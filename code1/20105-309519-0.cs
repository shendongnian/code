    public static class MyClassManager
    {
      private MyClass[] _myclasses;
      public MyClass[] MyClassArray
      {
        get
        {
          if(_myclasses == null)
          {
          _myClasses = new MyClass[50];
          for(int i = 0; i < 50;i++)
            _myClasses[i] = new MyClass();
          }
          return _myclasses;
    
        }
      }
    }
