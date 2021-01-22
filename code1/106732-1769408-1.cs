    MyType obj = new MyType();
    try
    {
      .... do stuff
    }
    finally
    {
      if(obj != null)
      {
          obj.Dispose();
      }
    }
   
