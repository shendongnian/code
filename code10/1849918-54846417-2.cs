    void ProcessFoos(ISomething<IFoo> something)
    {
      foreach (var output in something.Outputs())
      {
        if(output is IBar)
        {
          // do something IBar related
        }
        else if(output is IBaz)
        {
          // do something IBaz related
        }
      }
    }
