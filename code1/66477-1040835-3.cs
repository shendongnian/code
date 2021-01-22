    [Flags()]public enum CheckType
    {
      Form = 1,       
      QueryString = 2,
      TempData = 4,
    }
    
    void PerformActions( CheckType c )
    {
      // array of bits set in the parameter {c}
      bool[] actionMask = { false, false, false };
      // array of delegates to the corresponding actions we can invoke...
      Action availableActions = { DoSomething, DoSomethingElse, DoAnotherThing };
    
      // disassemble the flags into a array of booleans
      for( int i = 0; i < actionMask.Length; i++ )
        actionMask[i] = (c & (1 << i)) != 0;
      // for each set flag, dispatch the corresponding action method
      for( int actionIndex = 0; actionIndex < actionMask.Length; actionIndex++ )
      {
          if( actionFlag )
              availableActions[actionIndex](); // invoke the corresponding action
      }
    }
