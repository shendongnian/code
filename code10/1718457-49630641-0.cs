    class Engine : IEngine
    {
      private bool VerifyEngine()
      { return true; }
    
      private bool CheckHeat()
      { return true; }
    
      public bool Start()
      {
        if (VerifyEngine() && CheckHeat())
        {
          // business logic...
          return true;
        }
        return false;
      }
    }
