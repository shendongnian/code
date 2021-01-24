    public void MyAction()
    {
         var sessionState = Session[MySessionObject] as MySessionState;
         if (sessionState == null)
         {
             sessionState = new MySessionState();
         }
    
         sessionState.FirstName = "SomeName";
         sessionState.LastName = "SomeOtherName";
    
         /// Process this session object
    
    
         Session[MySessionObjectKey] = sessionState;
    }
