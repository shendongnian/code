    class CategoryHandlerWrapper : ICategoryHandler
    {
      ICategoryHandler instance;
      private DateTime expiry = DateTime.MinValue;
    
      public int A()
      {
        return Instance().A();
      }
    
      public bool HasExpired
        {
            get return DateTime.Now > expiry;
        }
    
      private CategoryHandler Instance()
        {
            if(HasExpired)
            {
                //Dispose and reconstruct
            }
            else
            {
                //Use existing instance
            }
        }
    }
