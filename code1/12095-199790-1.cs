    public void Foo(int a, int b, int? c)
    {
      if(c.HasValue)
      {
        // do something with a,b and c
      }
      else
      {
        // do something with a and b only
      }  
    }
