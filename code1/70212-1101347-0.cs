    class MyClass
    {
      public Action<int> TheAction {get;set;}
    
      public void DoAction(int x)
      {
        if (TheAction != null)
        {
          TheAction(x);
        }
      }
    }
