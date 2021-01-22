    void Recursive(int x)
    {
      // maintain the recursion path information
      path.Push(x);
    
      try
      {
        // do some stuff and recursively call the method
        Recursive(x + 6);
      }
      finally
      {
        // maintain the recursion path information
        path.Pop()
      }
    }
    
    void Recursive2(int x)
    {
      try
      {
         Recursive(x);
      }
      catch()
      {
          // Whatever
      }
    }
