    IsVisibleHandler
    {
    
      private bool[] b = new bool[10000];
    
      public bool GetIsVisible(int x)
      {
      return !b[x]
      }
    
      public void SetIsVisibleTrueAt(int x)
      {
      b[x] = false //!true
      }
    }
