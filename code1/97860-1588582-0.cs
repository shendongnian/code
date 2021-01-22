    public void Recursive(int x)
    {
      try
      {
        _Recursive(x)
      }
      catch
      { 
        throw new RecursionException(path.ToString(), ex);
        clear path, we know we are at the top at this point
      }
    }
     
    private void _Recursive(int x)
    {
        // maintain the recursion path information
        path.Push(x);
    
        _Recursive(x + 6);
    
        //maintain the recursion path information
        //note this is not in a catch so will not be called if there is an exception
        path.Pop()
    }
